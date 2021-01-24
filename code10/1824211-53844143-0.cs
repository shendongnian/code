    using System;
    using System.Collections.Generic;
    namespace StackOverFlow {
        public static class Program {
            # Store everything here
            private static Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            public static void Main(string[] args) {
                // Read all lines into array
                string[] lines = System.IO.File.ReadAllLines(@"Log.txt");
                foreach (string line in lines) {
                    // Split line by whitespace
                    string[] columns = line.Split(' ');
                    // Key is second column
                    string key = columns[1];
                    // Add line to dictionary, also making sure list is initialised
                    if (!data.ContainsKey(key)) {
                        data.Add(key, new List<string>());
                    }
                    data[key].Add(line);
                }
                // Print out results
                foreach (KeyValuePair<string, List<string>> entry in data) {
                    Console.WriteLine(entry.Key);
                    foreach (string line in entry.Value) {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine();
                }
            }
        }
    } 
