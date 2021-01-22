    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main(String[] args)
        {
            String s = "skvb sdkvkd s  kc wdkck sdkd sdkje sksdjs skd";
    
            String j = Justify(s, s.Length + 5);
            Console.WriteLine("Initial: " + s);
            Console.WriteLine("Result:  " + j);
            Console.ReadKey();
        }
    
        public static String Justify(String s, Int32 targetWidth)
        {
            if (targetWidth <= s.Length)
                return s;
    
            IDictionary<Int32, Int32> spaceOffsetsToParts = new Dictionary<Int32, Int32>();
            String[] parts = s.Split(' ');
            for (Int32 partIndex = 0, offset = 0; partIndex < parts.Length; partIndex++)
            {
                spaceOffsetsToParts.Add(offset - 1, partIndex);
                offset += parts[partIndex].Length + 1;
            }
    
            Int32 middle = s.Length / 2;     
            IList<Int32> orderedInsertOffsets = new List<Int32>();
            for (Int32 i = 0; i < middle; i++)
            {
                Int32 posUpper = middle + i;
                if (s[posUpper] == ' ')
                {
                    orderedInsertOffsets.Add(posUpper);
                }
    
                Int32 posLower = middle - i;
                if (s[posLower] == ' ')
                {
                    orderedInsertOffsets.Add(posLower);
                }
            }
    
            for (Int32 j = 0; j < targetWidth - s.Length; j++)
            {
                Int32 offset = orderedInsertOffsets[j];
                Int32 partIndex = spaceOffsetsToParts[offset];
                parts[partIndex] += ' ';
            }
            return String.Join(" ", parts);
        }
    }
