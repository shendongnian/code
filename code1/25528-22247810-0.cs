    using System;
    class ASCII
    {
    public static void Main(string [] args)
    {
    string s;
    Console.WriteLine(" Enter Your Sentence ");
    s = Console.ReadLine();
    foreach (char c in s)
    {
    Console.WriteLine((int)c);
    }
    }
    }
