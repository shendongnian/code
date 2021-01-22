    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Alphabetty
    {
        class Program
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            static int cursor = 0;
            static int prefixCursor;
            static string prefix = string.Empty;
            static bool done = false;
            static void Main(string[] args)
            {
                string s = string.Empty;
                while (s != "Done")
                {
                    s = GetNextString();
                    Console.WriteLine(s);
                }
                Console.ReadKey();
    
            }        
            static string GetNextString()
            {
                if (done) return "Done";
                char? nextLetter = GetNextLetter(ref cursor);
                if (nextLetter == null)
                {
                    char? nextPrefixLetter = GetNextLetter(ref prefixCursor);
                    if(nextPrefixLetter == null)
                    {
                        done = true;
                        return "Done";
                    }
                    prefix = nextPrefixLetter.Value.ToString();
                    nextLetter = GetNextLetter(ref cursor);
                }
    
                return prefix + nextLetter;
            }
    
            static char? GetNextLetter(ref int letterCursor)
            {
                if (letterCursor == alphabet.Length)
                {
                    letterCursor = 0;
                    return null;
                }
    
                char c = alphabet[letterCursor];
                letterCursor++;
                return c;
            }
        }
    }
