    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        public static String Justify(String s, Int32 count)
        {
            if (count <= 0)
                return s;
    
            Int32 middle = s.Length / 2;
            IDictionary<Int32, Int32> spaceOffsetsToParts = new Dictionary<Int32, Int32>();
            String[] parts = s.Split(' ');
            for (Int32 partIndex = 0, offset = 0; partIndex < parts.Length; partIndex++)
            {
                spaceOffsetsToParts.Add(offset, partIndex);
                offset += parts[partIndex].Length + 1; // +1 to count space that was removed by Split
            }
            foreach (var pair in spaceOffsetsToParts.OrderBy(entry => Math.Abs(middle - entry.Key)))
            {
                count--;
                if (count < 0)
                    break;
                parts[pair.Value] += ' ';
            }
            return String.Join(" ", parts);
        }
        static void Main(String[] args) {
            String s = "skvb sdkvkd s  kc wdkck sdkd sdkje sksdjs skd";
            String j = Justify(s, 5);
            Console.WriteLine("Initial: " + s);
            Console.WriteLine("Result:  " + j);
            Console.ReadKey();
        }
    }
