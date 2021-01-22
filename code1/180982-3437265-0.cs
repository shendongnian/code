    using System;
    
    namespace ConsoleApplication1 {
        class Program {
            static void permuteN(string prefix, int len) {
                if (len == 0) {
                    System.Console.WriteLine(prefix);
                    return;
                }
                permuteN(prefix + "0", len - 1);
                permuteN(prefix + "1", len - 1);
            }
            static void permute(int len) {
                for (int i = 1; i <= len; i++)
                    permuteN("", i);
            }
    
            static void Main(string[] args) {
                permute(3);
            }
        }
    }
