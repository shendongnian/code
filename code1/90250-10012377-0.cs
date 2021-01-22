    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace SplitFunction
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "hello, how are you doing today?";
                string[] chunks = SplitIntoChunks(text, 3,false);
                if (chunks != null)
                {
                    chunks.ToList().ForEach(e => Console.WriteLine(e));
                }
    
                Console.ReadKey();
            }
    
            private static string[] SplitIntoChunks(string text, int chunkSize, bool truncateRemaining)
            {
                string chunk = chunkSize.ToString(); 
                string pattern = truncateRemaining ? ".{" + chunk + "}" : ".{1," + chunk + "}";
    
                string[] chunks = null;
                if (chunkSize > 0 && !String.IsNullOrEmpty(text))
                    chunks = (from Match m in Regex.Matches(text,pattern)select m.Value).ToArray(); 
                
                return chunks;
            }     
        }
    }
