    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace yourNamespace
    {
        class Char_frrequency
        {
        Dictionary<Char, int> countMap = new Dictionary<char, int>();
        public String getStringWithUniqueCharacters(String input)
        {
            List<Char> uniqueList = new List<Char>();
            foreach (Char x in input)
            {
                if (countMap.ContainsKey(x))
                {
                    countMap[x]++;
                }
                else
                {
                    countMap.Add(x, 1);
                }
                if (!uniqueList.Contains(x))
                {
                    uniqueList.Add(x);
                }
            }
            Char[] uniqueArray = uniqueList.ToArray();
            return new String(uniqueArray);
        }
        public int getFrequency(Char x)
        {
            return countMap[x];
        }
    }
    }
