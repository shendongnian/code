    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp4
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader("DISTRICT.DISTRICT_COURT_.11.13.18.AM.000B.CAL.txt");
    
                StreamWriter writer = new StreamWriter("outtext.csv");
    
                int counts = 0;
                string line ;
    
                SortedSet<string> uniqueLine = new SortedSet<string>();
    
                Regex findWords = new Regex(@"(APT.|BPD|18IF|SHP|SFF|CLS:|BOND|ATTY|\(T\)|\(M\)|\(F\)|\(I\))");
    
                while ((line = reader.ReadLine()) != null)
                {
                    if (uniqueLine.Contains(line))
                    {
                        counts++;
                    }
                    else
                    {
                        uniqueLine.Add(line);
                        writer.WriteLine(line);
                    }
                    Match aMatch = findWords.Match(line);
    
                    if (aMatch.Success)
                    {
                        Console.WriteLine(line);
                    }
                    
                }
    
                writer.WriteLine("Count:{0}", counts);
                writer.Close();
                
    
                Console.ReadKey();
            }
        }
    }
