﻿using System;
using Projektni_FMSI;
using System.Collections.Generic;
using System.IO;

//Automat.enterSpecification();

class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("===================================");
        Console.WriteLine("WELCOME: ");
        Console.WriteLine("===================================");
        Console.WriteLine("===================================");
        Console.WriteLine("You have these options: ");
        Console.WriteLine("1-Execute automata\n2-Construct union\n3-Construct intersection\n4-Construct difference\n5-Connect two languages\n6-Apply Kleene star" +
                            "\n7-Chain operations\n8-Find shortest word\n9-Find longest word\n10-Check out if language is final\n11-Minimise DKA\n" +
                            "12-Transform ENKA to DKA\n13-Check if two languages are the same\n14-Transform regular expression to automata" +
                            "\n15-Load Specification ");
        Console.WriteLine("--exit to finish!");       
        string input = "";
        Automat a = null;
        a = new();
        Automat b = null;
        b = new();
        Console.WriteLine("Enter your option: ");
        do
        {
            input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Construct your automata: ");
                a.makeAutomata();
                a.runAutomata();
            }
            else if (input == "2")
            {
                Console.WriteLine("Construct your language: ");
                Automat.makeLanguagesForUnionIntersectionDifference(ref a);
                Automat res = a.findUnion();
                Console.WriteLine("Result: ");
                res.printStatesAndAlphabet();
            }
            else if (input == "3")
            {
                Console.WriteLine("Construct your language: ");
                Automat.makeLanguagesForUnionIntersectionDifference(ref a);
                Automat res = a.findIntersection();
                Console.WriteLine("Result: ");
                res.printStatesAndAlphabet();

            }
            else if (input == "4")
            {
                Console.WriteLine("Construct your language: ");
                Automat.makeLanguagesForUnionIntersectionDifference(ref a);
                Automat res = a.findDifference();
                Console.WriteLine("Result: ");
                res.printStatesAndAlphabet();
            }
            else if (input == "5")
            {
                Console.WriteLine("Construct your language: ");
                Automat.makeLanguagesForUnionIntersectionDifference(ref a);
                Automat res = a.connectLanguages();
                Console.WriteLine("Result: ");
                res.printStatesAndAlphabet();
            }
            else if (input == "6")
            {
                Console.WriteLine("Construct your language: ");
                Automat.makeLanguagesForUnionIntersectionDifference(ref a);
                Automat res = a.applyKleeneStar();
                Console.WriteLine("Result: ");
                res.printStatesAndAlphabet();
            }
            else if (input == "7")
            {
                Console.WriteLine("Chaining has started: ");
                Automat.chainOperations();
            }
            else if (input == "8")
            {
                Console.WriteLine("Construct your language: ");
                Automat.makeLanguagesForUnionIntersectionDifference(ref a);
                Console.WriteLine("Shortest word (if it exists) is: " + a.findShortestPath());
            }
            else if (input == "9")
            {
                Console.WriteLine("Construct your language: ");
                Automat.makeLanguagesForUnionIntersectionDifference(ref a);
                //a.printStatesAndAlphabet();
                Console.WriteLine("Longest word (if it exists) is: " + a.findLongestPath());
            }
            else if (input == "10")
            {
                Console.WriteLine("Construct your language: ");
                Automat.makeLanguagesForUnionIntersectionDifference(ref a); 
                if (a.isLanguageFinal())
                {
                    Console.WriteLine("Language IS final!");
                }
                else
                {
                    Console.WriteLine("Language is NOT final!");
                }
            }
            else if (input == "11")
            {
                Console.WriteLine("Construct your automata: ");
                a.makeAutomata();
                Automat res;
                if(a.checkIfIsENKA())
                {
                    Console.WriteLine("You've entered E-NKA, we'll convert it to DKA and then minimise it...");
                    a = a.convertENKAtoDKA();
                    res = a.minimiseAutomata();
                    Console.WriteLine("Minimised automata: ");
                    res.printStatesAndAlphabet();
                }
                else
                {
                    res = a.minimiseAutomata();
                    Console.WriteLine("Minimised automata: ");
                    res.printStatesAndAlphabet();
                }
            }
            else if (input == "12")
            {
                Console.WriteLine("Construct your automata: ");
                a.makeAutomata();
                if (a.checkIfIsENKA())
                {
                    Automat rez = a.convertENKAtoDKA();
                    rez.printStatesAndAlphabet();
                }
                else
                {
                    Console.WriteLine("You've entered DKA anyways, why would I minimise it?");
                }
            }
            else if (input == "13")
            {
                Automat.makeLanguagesForUnionIntersectionDifference(ref a);
                Automat.makeLanguagesForUnionIntersectionDifference(ref b);
                if (a.compareTwoAutomatas(b))
                {
                    Console.WriteLine("Automatas are the same!");
                }
                else
                {
                    Console.WriteLine("Automatas are not the same!");
                }
            }
            else if (input == "14")
            {
                string regexp;
                Console.WriteLine("Enter your regular expression: ");
                regexp = Console.ReadLine();
                Console.WriteLine("Converting...");
                Automat convertedAutomata = Automat.makeAutomataFromRegularExpression(regexp);
                convertedAutomata.printStatesAndAlphabet();
            }
            else if (input == "15")
            {
                AutomataSpecification.enterSpecification(args);
            }
            else if (input == "--exit")
            {

            }
            else
            {
                Console.WriteLine("Wrong option, try again!");
            }
        } while (input != "--exit");
    }
}

//var path = Path.Combine("./" + "newdoc" + ".txt");
//string[] elements = File.ReadAllLines(path);
/*LexicalAnalysis lexicalAnalysis = new(elements);
bool res = lexicalAnalysis.lexicalAnalysisForAutomata(elements);*/


//Automat g = new();
//Automat a = new(), b = new();
//a.alphabet.Add('a');
//a.alphabet.Add('b');
//Automat res = a.transformRegularExpressionToAutomata("(b*a)+a*(a+(a+b)b)");
//res.addDeadStatesDKA();
//res.printStatesAndAlphabet();
/*foreach(var finalState in res.finalStates)
{
    Console.WriteLine(finalState);
}*/
//Automat convert = res.convertENKAtoDKA();
//convert.printStatesAndAlphabet();
//Automat minimise = convert.minimiseAutomata();
//minimise.printStatesAndAlphabet();
//bool check = a.checkIfTwoRegularExpressionsAreTheSame("a+b*", "(a+b)*");
//res = res.convertENKAtoDKA();
//res = res.minimiseAutomata();
//res.printStatesAndAlphabet();

//WORKS
/*var path = Path.Combine("./newdoc.txt");
string[] elements = File.ReadAllLines(path);
foreach(var element in elements)
{
    Console.WriteLine(element);
}*/

//Automat a = new();

//Automat.enterSpecification();
//Automat rez = Automat.makeAutomataFromRegularExpression("(a+b)*ab+a");
/*if(rez.acceptsENKA("aaabbbab"))
{
    Console.WriteLine("Accepts!");
}*/

//a.makeAutomata();
//Automat.chainOperations();
//Automat f = new();
//Automat.chainOperations();

/*g.StartState = "q0";
g.states.Add("q0");
g.states.Add("q1");
g.states.Add("q2");
g.states.Add("q3");
g.states.Add("q4");
g.states.Add("q5");
g.states.Add("q6");
g.alphabet.Add('E');
g.alphabet.Add('a');
g.alphabet.Add('b');
g.finalStates.Add("q0");
List<string> tempList = new();
tempList.Add("q1");
g.deltaForEpsilon[("q0", 'b')] = tempList;
tempList.Clear();
tempList.Add("q2");
g.deltaForEpsilon[("q1", 'a')] = tempList;
tempList.Clear();
tempList.Add("q2");
g.deltaForEpsilon[("q1", 'b')] = tempList;
tempList.Clear();
tempList.Add("q5");
g.deltaForEpsilon[("q1", 'E')] = tempList;
tempList.Clear();
tempList.Add("q5");
g.deltaForEpsilon[("q2", 'a')] = tempList;
tempList.Clear();
tempList.Add("q6");
g.deltaForEpsilon[("q2", 'E')] = tempList;
tempList.Clear();
tempList.Add("q3");
g.deltaForEpsilon[("q2", 'b')] = tempList;
tempList.Clear();
tempList.Add("q6");
g.deltaForEpsilon[("q3", 'a')] = tempList;
tempList.Clear();
tempList.Add("q0");
g.deltaForEpsilon[("q4", 'b')] = tempList;
tempList.Clear();
tempList.Add("q0");
tempList.Add("q4");
g.deltaForEpsilon[("q5", 'a')] = tempList;
tempList.Clear();
tempList.Add("q5");
g.deltaForEpsilon[("q6", 'E')] = tempList;
//g.printStatesAndAlphabet();
if(g.acceptsENKA("bab"))
{
    Console.WriteLine("Accepts!");
}*/

/*g.delta[("q0", 'a')] = "q1";
g.delta[("q0", 'b')] = "q2";
g.delta[("q1", 'a')] = "q4";
g.delta[("q1", 'b')] = "q1";
g.delta[("q2", 'a')] = "q3";
g.delta[("q2", 'b')] = "q2";
g.delta[("q3", 'a')] = "q5";
g.delta[("q3", 'b')] = "q5";*/
//g.delta[("q4", 'a')] = "q0";
//g.finalStates.Add("q4");
//g.finalStates.Add("q2");
//g.finalStates.Add("q0");
//Console.WriteLine(g.isLanguageFinal());

//g.delta[("q5", 'a')] = "q2";
//g.delta[("q4", 'a')] = "p2";
//g.delta[("q4", 'b')] = "p1";

//Automat convert = g.transformRegularExpressionToAutomata("ab((a+ab)*b)a+b");
//Automat convert = g.transform("ab((a+ab)*b)a+b");

//g.finalStates.Add("q5");

//Console.WriteLine(g.findShortestPath());

//a.makeAutomata();
//g.makeAutomata();

/*a.StartState = "q0";
a.states.Add("q0");
a.states.Add("q1");
a.states.Add("q2");
a.states.Add("q3");
a.states.Add("q4");
a.states.Add("q5");
a.states.Add("q6");
a.states.Add("q7");
a.alphabet.Add('a');
a.alphabet.Add('b');
a.alphabet.Add('c');
a.alphabet.Add('a');
a.alphabet.Add('b');
a.finalStates.Add("q1");
a.finalStates.Add("q3");
a.finalStates.Add("q4");
a.finalStates.Add("q7");
a.delta[("q0", 'a')] = "q1";
a.delta[("q0", 'b')] = "q2";
a.delta[("q0", 'c')] = "q4";
a.delta[("q1", 'b')] = "q5";
a.delta[("q1", 'c')] = "q5";
//a.delta[("q2", 'a')] = "q2";
a.delta[("q2", 'c')] = "q3";
a.delta[("q4", 'a')] = "q6";
a.delta[("q6", 'a')] = "q7";
Console.WriteLine(a.findLongestPath());*/


//a.delta[("q1", '1')] = "q4";
//a.delta[("q1", '0')] = "q3";

//a.delta[("q2", 'a')] = "q1";
//a.delta[("q2", 'b')] = "q2";
/*Automat b = new();
b.makeAutomata();
Automat c = b.convertENKAtoDKA();
c.printStatesAndAlphabet();
Console.WriteLine("Final states: ");
foreach(var final in c.finalStates)
{
    Console.Write(final + " ");
}*/

//Automat c = Automat.transformRegularExpressionToAutomata("(ab+c)*");
//c.printStatesAndAlphabet();

//b.printStatesAndAlphabet();
/*a.delta[("q3", 'a')] = "q4";
a.delta[("q3", 'b')] = "q3";

a.delta[("q4", 'a')] = "q4";
a.delta[("q4", 'b')] = "q3";*/
//a = a.minimiseAutomata();
//a.printStatesAndAlphabet();
//a.chainOperations();
/*a.delta[("q3", '0')] = "q7";
a.delta[("q3", '1')] = "q4";
a.delta[("q4", '0')] = "q7";
a.delta[("q4", '1')] = "q3";
a.delta[("q5", '0')] = "q8";
a.delta[("q5", '1')] = "q6";

a.delta[("q6", '0')] = "q8";
a.delta[("q6", '1')] = "q5";
a.delta[("q7", '0')] = "q9";
a.delta[("q7", '1')] = "q7";

a.delta[("q8", '0')] = "q9";
a.delta[("q8", '1')] = "q8";
a.delta[("q9", '0')] = "q9";
a.delta[("q9", '1')] = "q9";*/
//a.delta[("q10", '0')] = "q0";
//a.delta[("q10", '1')] = "q6";

//b = a.applyKleeneStar();
/*b = a.connectLanguages(g);
b.printStatesAndAlphabet();
//b.printStatesAndAlphabet();
Automat c = b.convertENKAtoDKA();
c.printStatesAndAlphabet();*/
//c.printStatesAndAlphabet();

//b = a.minimiseAutomata();

/*if(c.AcceptsDKA("aaba"))
{
    Console.WriteLine("Accepted!");
}*/

//b.makeAutomata();
//b.makeAutomata();
//a.compareTwoAutomatas(b);
//Automat res = a.convertENKAtoDKA();
//res.printStates();
//a.callGraph();
//Automat b = new();
//b.makeAutomata();
//a.printStates();
//a.callGraph();
//Automat go = a.connectLanguages(b);
//go.printStates();
//Automat b = new Automat();
//b.makeAutomata();
//Automat res = a.connectLanguages(b);
