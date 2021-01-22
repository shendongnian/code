    using System;
    using System.Collections.Generic;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
            string original = "phenomenal";
            string pattern = "*xo**q*t**";
    
            string[] replacements = StringUtility.GetReplacementStrings(original, pattern, true);
    
            foreach (string replacement in replacements)
                Console.WriteLine(replacement);
    
            Console.Read();
        }
    
        public static class StringUtility
        {
            public static string[] GetReplacementStrings(string original, string pattern, bool includeOriginal)
            {
                // pattern and original might not be same length
                int maxIndex = Math.Max(original.Length, pattern.Length);
    
                List<int> positions = GetPatternPositions(pattern, maxIndex, '*');
                List<int[]> subsets = ArrayUtility.CreateSubsets(positions.ToArray());
                List<string> replacements = GenerateReplacements(original, pattern, subsets);
    
                if (includeOriginal)
                    replacements.Insert(0, original);
    
                return replacements.ToArray();
            }
    
            private static List<string> GenerateReplacements(string original, string pattern, List<int[]> subsets)
            {
                List<string> replacements = new List<string>();
                char[] temp = new char[original.Length];
    
                foreach (int[] subset in subsets)
                {
                    original.CopyTo(0, temp, 0, original.Length);
                    foreach (int index in subset)
                    {
                        temp[index] = pattern[index];
                    }
    
                    replacements.Add(new string(temp));
                }
    
                return replacements;
            }
    
            private static List<int> GetPatternPositions(string pattern, int maxIndex, char excludeCharacter)
            {
                List<int> positions = new List<int>();
    
                for (int i = 0; i < maxIndex; i++)
                {
                    if (pattern[i] != excludeCharacter)
                        positions.Add(i);
                }
    
                return positions;
            }
        }
    
        public static class ArrayUtility
        {
            public static List<T[]> CreateSubsets<T>(T[] originalArray)
            {
                List<T[]> subsets = new List<T[]>();
    
                for (int i = 0; i < originalArray.Length; i++)
                {
                    int subsetCount = subsets.Count;
                    subsets.Add(new T[] { originalArray[i] });
    
                    for (int j = 0; j < subsetCount; j++)
                    {
                        T[] newSubset = new T[subsets[j].Length + 1];
                        subsets[j].CopyTo(newSubset, 0);
                        newSubset[newSubset.Length - 1] = originalArray[i];
                        subsets.Add(newSubset);
                    }
                }
    
                return subsets;
            }
        }
    }
