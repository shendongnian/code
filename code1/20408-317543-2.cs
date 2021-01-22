    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    
    namespace ConsoleApplication1Test
    {
        class Program
        {
            static char[] my_func( char[] my_chars, int level)
            {
                if (level > 1)
                    my_func(my_chars, level - 1);
                my_chars[(my_chars.Length - level)]++;
                if (my_chars[(my_chars.Length - level)] == ('Z' + 1))
                {
                    my_chars[(my_chars.Length - level)] = 'A';
                    return my_chars;
                }
                else
                {
                    Console.Out.WriteLine(my_chars);
                    return my_func(my_chars, level);
                }
            }
            static void Main(string[] args)
            {
                char[] text = { 'A', 'A', 'A', 'A' };
                my_func(text,text.Length);
                Console.ReadKey();
            }
        }
    }
