    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    class Solution 
    {
        static void Main(String[] args) 
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int threshold = n / 2;
            List<string>[] stringMap = new List<string>[100];
            for(int a0 = 0; a0 < n; a0++){
                string[] tokens_x = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(tokens_x[0]);
                if(stringMap[x] == null)
                {
                    stringMap[x] = new List<string>();
                }
                stringMap[x].Add((a0 >= threshold ? tokens_x[1] : "-"));
            }
            
            List<string> output = new List<string>();
            for(int i = 0; i < stringMap.Length; i++)
            {
                if(stringMap[i] == null)
                {
                    continue;
                }
                
                output.AddRange(stringMap[i]);
            }
            
            Console.WriteLine(string.Join(" ", output));
        }
    }
