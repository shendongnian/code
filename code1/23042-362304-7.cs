    using System;
    using System.IO;
    static class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("foo.txt");
            string[][] grid = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                grid[i] = lines[i].Split(',');
            }
    
            int totalCount = 0, maleCount = 0, femaleCount = 0,
                m1Total = 0, m2Total = 0, m3Total = 0,
                m1MaleTotal = 0, m1FemaleTotal = 0;
            foreach (string[] line in grid)
            {
                totalCount++;
                int m1 = int.Parse(line[3]),
                    m2 = int.Parse(line[4]),
                    m3 = int.Parse(line[5]);
                m1Total += m1;
                m2Total += m2;
                m3Total += m3;
                switch (line[1].Trim())
                {
                    case "male":
                        maleCount++;
                        m1MaleTotal += m1;
                        break;
                    case "female":
                        femaleCount++;
                        m1FemaleTotal += m1;
                        break;
                }
            }
            Console.WriteLine("Rows: " + totalCount);
            Console.WriteLine("Total m1: " + m1Total);
            Console.WriteLine("Average m1: " + ((double)m1Total)/totalCount);
            Console.WriteLine("Male Average m1: " + ((double)m1MaleTotal) / maleCount);
            Console.WriteLine("Female Average m1: " + ((double)m1FemaleTotal) / femaleCount);
        }
    }
