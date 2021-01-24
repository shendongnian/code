    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication58
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string[] inputs = { "001_first_match", "010_second_match", "011_third_match" };
                foreach (string input in inputs)
                {
                    Console.WriteLine("Input '{0}' found in HashTable : {1}", input, Matches.Keys.Cast<string>().Any(x => input.Contains(x)) ? "True" : "False");
                }
                Console.ReadLine();
     
            }
            public static Hashtable Matches = new Hashtable
            {
                {"first_match", "One"},
                {"second_match", "Two"},
                {"third_match", "Three"},
                {"fourth_match", "Four!"},
                {"fifth_match", "Five"}
            };
        }
     
    }
