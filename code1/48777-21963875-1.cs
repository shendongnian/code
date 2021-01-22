    class Permutation
    {
        public static List<string> Permutate(string seed, List<string> lstsList)
        {
            loopCounter = 0;
            // string s="\w{0,2}";
            var lstStrs = PermuateRecursive(seed);
            Trace.WriteLine("Loop counter :" + loopCounter);
            return lstStrs;
        }
        // Recursive function to find permutation
        private static List<string> PermuateRecursive(string seed)
        {
            List<string> lstStrs = new List<string>();
            if (seed.Length > 2)
            {
                for (int i = 0; i < seed.Length; i++)
                {
                    str = Swap(seed, 0, i);
                    PermuateRecursive(str.Substring(1, str.Length - 1)).ForEach(
                        s =>
                        {
                            lstStrs.Add(str[0] + s);
                            loopCounter++;
                        });
                    ;
                }
            }
            else
            {
                lstStrs.Add(seed);
                lstStrs.Add(Swap(seed, 0, 1));
            }
            return lstStrs;
        }
        //Loop counter variable to count total number of loop execution in various functions
        private static int loopCounter = 0;
        //Non recursive  version of permuation function
        public static List<string> Permutate(string seed)
        {
            loopCounter = 0;
            List<string> strList = new List<string>();
            strList.Add(seed);
            for (int i = 0; i < seed.Length; i++)
            {
                int count = strList.Count;
                for (int j = i + 1; j < seed.Length; j++)
                {
                    for (int k = 0; k < count; k++)
                    {
                        strList.Add(Swap(strList[k], i, j));
                        loopCounter++;
                    }
                }
            }
            Trace.WriteLine("Loop counter :" + loopCounter);
            return strList;
        }
        private static string Swap(string seed, int p, int p2)
        {
            Char[] chars = seed.ToCharArray();
            char temp = chars[p2];
            chars[p2] = chars[p];
            chars[p] = temp;
            return new string(chars);
        }
    }
