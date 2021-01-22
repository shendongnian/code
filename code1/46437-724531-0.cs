    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                List<string> xx = new List<string>() { "xx", "yy", "zz" };
                List<string> yy = new List<string>() { "11", "22", "33" };
                List<string> zz = new List<string>() { "aa", "bb", "cc" };
                List<List<string>> x = new List<List<string>>() { xx, yy, zz, xx, yy, zz, xx, yy };
                foreach(List<string> list in x.Distinct()) {
                    foreach(string s in list) {
                        Console.WriteLine(s);
                    }
                }
            }
        }
    }
