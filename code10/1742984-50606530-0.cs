    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    namespace Subst
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var map = new Dictionary<string, string>{
                    {"Word", "#Word."},
                    {"anotherWord", "#anotherWord."},
                    {"Word2", "#Word2."}
                };
                var input = "Word Word2 anotherWord and some other stuff";
                
                foreach(var mapping in map) {
                    input = Regex.Replace(input, String.Format("\\b{0}\\b", mapping.Key), mapping.Value);
                }
                
                Console.WriteLine(input);
            }
        }
    }
