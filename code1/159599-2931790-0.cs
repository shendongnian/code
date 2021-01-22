    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication
    {
        class Program
        {
            private static Random r = new Random();
            // Create a string with randomly chosen letters, of a randomly chosen
            // length between the given min and max.
            private static string RandomString(int minLength, int maxLength)
            {
                StringBuilder b = new StringBuilder();
                int length = r.Next(minLength, maxLength);
                for (int i = 0; i < length; ++i)
                {
                    b.Append(Convert.ToChar(65 + r.Next(26)));
                }
                return b.ToString();
            }
            static void Main(string[] args)
            {
                int             stringCount = 10000;                    // number of random strings to generate
                StringBuilder   pattern     = new StringBuilder();      // our regular expression under construction
                HashSet<String> strings     = new HashSet<string>();    // a set of the random strings (and their
                                                                        // prefixes) we created, for verifying the
                                                                        // regex correctness
                // generate random strings, track their prefixes in the set,
                // and add their prefixes to our regular expression
                for (int i = 0; i < stringCount; ++i)
                {
                    // make a random string, 2-5 chars long
                    string nextString = RandomString(2, 5);
                    // for each prefix of the random string...
                    for (int prefixLength = 1; prefixLength <= nextString.Length; ++prefixLength)
                    {
                        string prefix = nextString.Substring(0, prefixLength);
                        // ...add it to both the set and our regular expression pattern
                        if (!strings.Contains(prefix))
                        {
                            strings.Add(prefix);
                            pattern.Append(((pattern.Length > 0) ? "|" : "") + "^" + prefix + "$");
                        }
                    }
                }
                // create a regex from the pattern (and time how long that takes)
                DateTime regexCreationStartTime = DateTime.Now;
                Regex r = new Regex(pattern.ToString());
                DateTime regexCreationEndTime = DateTime.Now;
                // make sure our regex correcly matches all the strings, and their
                // prefixes (and time how long that takes as well)
                DateTime matchStartTime = DateTime.Now;
                foreach (string s in strings)
                {
                    if (!r.IsMatch(s))
                    {
                        Console.WriteLine("uh oh!");
                    }
                }
                DateTime matchEndTime = DateTime.Now;
                // generate some new random strings, and verify that the regex
                // indeed does not match the ones it's not supposed to.
                for (int i = 0; i < 1000; ++i)
                {
                    string s = RandomString(2, 5);
                    if (!strings.Contains(s) && r.IsMatch(s))
                    {
                        Console.WriteLine("uh oh!");
                    }
                }
                Console.WriteLine("Regex create time: {0} millisec", (regexCreationEndTime - regexCreationStartTime).TotalMilliseconds);
                Console.WriteLine("Average match time: {0} millisec", (matchEndTime - matchStartTime).TotalMilliseconds / stringCount);
                Console.ReadLine();
            }
        }
    }
