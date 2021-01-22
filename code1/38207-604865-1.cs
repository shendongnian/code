    using System;
    using VB = Microsoft.VisualBasic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(VB.Strings.StrConv("QUICK BROWN", VB.VbStrConv.ProperCase, 0));
                Console.ReadLine();
            }
        }
    }
