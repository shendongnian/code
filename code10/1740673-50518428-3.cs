    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    
    namespace CoreConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var p = new Parser()
                {
                    Steps =
                    {
                        new ParserStep()
                        {
                            Data = { Tuple.Create("AOC", "Add On Card") },
                            ToDo = (a => Console.WriteLine($"Product Family = {a}"))
                        },
                        new ParserStep()
                        {
                            Data =
                            {
                                Tuple.Create("S", "Standard"),
                                Tuple.Create("P", "Proprietary"),
                                Tuple.Create("C", "MicroLP"),
                                Tuple.Create("M", "Super IO"),
                                Tuple.Create("MH", "SIOM Hybrid")
                            },
                            ToDo = (a => Console.WriteLine($"Form Factor = {a}"))
                        }
                    }
                };
                p.Run("AOC-S");
                Console.ReadLine();
            }
        }
    
        public class ParserStep
        {
            public Action<string> ToDo { get; set; }
            public List<Tuple<string, string>> Data { get; set; } = new List<Tuple<string, string>>();
            public bool Optional { get; set; } = false;
    
            public string ProcessStep(string message)
            {
                foreach (var d in Data)
                {
                    if (message.StartsWith(d.Item1))
                    {
                        ToDo(d.Item2);
                        return message.Substring(d.Item1.Length);
                    }
                }
                if (!Optional)
                    throw new InvalidDataException();
                return message;
            }
        }
    
        public class Parser
        {
            public List<ParserStep> Steps { get; set; } = new List<ParserStep>();
    
            public void Run(string message)
            {
                foreach (var step in Steps)
                {
                    if (string.IsNullOrEmpty((message)))
                        return;
                    message = step.ProcessStep(message);
                    message = message.TrimStart('-');
                }
            }
        }
        
    }
