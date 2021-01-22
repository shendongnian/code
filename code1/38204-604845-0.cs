    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                StringBuilder sb = new StringBuilder();
                string sentence = "123The_quIck bROWN FOX1234";
    
                sentence = sentence.ToLower();
    
                char[] s = sentence.ToCharArray();
    
                bool atStart = true;
                char pChar = ' ';
    
                char[] spaces = { ' ', '_', '-' };
                char a;
                foreach (char c in s)
                {
                    if (atStart && char.IsDigit(c)) continue;
    
                    if (char.IsLetter(c))
                    {
                        a = c;
                        if (spaces.Contains(pChar))
                            a = char.ToUpper(a);
                        sb.Append(a);
                        atStart = false;
                    }
                    else if(char.IsDigit(c))
                    {
                        sb.Append(c);
                    }
                    pChar = c;
                }
    
                Console.WriteLine(sb.ToString());
                Console.ReadLine();
            }
        }
    }
