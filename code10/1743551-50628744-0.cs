    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication48
    {
        class Program
        {
            const int SIZE = 4;
            const string ThreeSpace = "   ";
            static void Main(string[] args)
            {
                int level = 0;
                Recursive(level);
                Console.ReadLine();
            }
            static void Recursive(int level)
            {
                if(level >= (2 * SIZE) - 1) return;
                if (level < SIZE)
                {
                    //grow larger
                    int index = SIZE - level - 1;
                    string leader = new string(' ', 2 * index);
                    string text = string.Join(ThreeSpace, new string((char)(index + 65), level + 1).Select(x => (char)(level + 65))).TrimEnd();
                    Console.WriteLine(leader + text);
                    Recursive(level + 1);
                }
                else
                {
                    //grow smaller
                    int index = level - SIZE + 1;
                    string leader = new string(' ', 2 * index);
                    string text = string.Join(ThreeSpace, new string((char)(index + 65 - 1), SIZE - index).Select(x => (char)(SIZE - index + 65 - 1))).TrimEnd();
                    Console.WriteLine(leader + text);
                    Recursive(level + 1);
                }
            }
        }
    }
