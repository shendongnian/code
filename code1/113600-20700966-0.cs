    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace FileHandling
    {
        class Class1
        {
            static void Main()
            {
                Console.WriteLine("Enter data");
                ConsoleKeyInfo k;
                //Console.WriteLine(k.KeyChar + ", " + k.Key + ", " + k.Modifiers );
                string str="";
                char ch;
                while (true)
                {
                    k = Console.ReadKey();
                    if ((k.Modifiers == ConsoleModifiers.Control) && (k.KeyChar == 23))
                    {
                        Console.WriteLine("\b");
                        break;
                    }
                    if (k.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("");
                        str += "\n";
                    }
                    ch = Convert.ToChar(k.KeyChar);
                    str += ch.ToString();
                }
                Console.WriteLine(str);
                Console.Read();
            }
        }
    }
