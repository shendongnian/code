    using System;
    using System.Collections.Generic;
                        
    public class Program
    {
        private static void AddWord(Dictionary<string, List<int>> d, string word, int index) {
            if (!d.ContainsKey(word)) {
                d.Add(word, new List<int>());	
            }
            
            d[word].Add(index);
        }
        
        private static List<int> GetIndexesForWord(Dictionary<string, List<int>> d, string word) {
            if (!d.ContainsKey(word)) {
                return new List<int>();
            } else {
                return d[word];
            }
        }
        
        public static void Main()
        {
            var stringsToFind = new[] { "one", "five", "seven" };
            
            var listsToTest = new[] {
                new[] { "two", "three", "four", "five" },
                new[] { "one", "two", "seven" },
                new[] { "one", "five", "seven" }
            };
            
            // Build a lookup that knows which words appear in which lists, even
            // if we don't care about those words.
            var keyToIndexes = new Dictionary<string, List<int>>();
            for (var listIndex = 0; listIndex < listsToTest.GetLength(0); listIndex++) {
                var listToTest = listsToTest[listIndex];
                foreach (var word in listToTest) {
                    AddWord(keyToIndexes, word, listIndex);
                }
            }
            
            // Report which lists have the target words.
            foreach (var target in stringsToFind) {
                Console.WriteLine("Lists with '{0}':", target);
                var indices = GetIndexesForWord(keyToIndexes, target);
                if (indices.Count == 0) {
                    Console.WriteLine("  <none>");
                } else {
                    var message = string.Join(", ", indices);
                    Console.WriteLine("  {0}", message);
                }
            }
        }
    }
