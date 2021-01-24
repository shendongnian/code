    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication98
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] input = { "FOD19-1", "FOD33-2", "FOD39", "SÅL1", "SÅL23-3", "SÅL31-1", "SÅL32-2", "SÅL33-1", "SÅL7-1" };
                Array.Sort(input, new MyCompare());
            }
        }
        public class MyCompare : IComparer<string>
        {
            const string pattern = @"(?'name'[^\d]+)(?'index'\d+)?-?(?'subindex'\d+)?";
            public int Compare(string a, string b)
            {
                if (a == b) return 0;
                int results = 0;
                Match matcha = Regex.Match(a, pattern);
                Match matchb = Regex.Match(b, pattern);
                string namea = matcha.Groups["name"].Value;
                int indexa = 0;
                int subindexa = 0;
                Boolean isAindexInt = int.TryParse(matcha.Groups["index"].Value, out indexa);
                Boolean isAsubindexInt = int.TryParse(matcha.Groups["subindex"].Value, out subindexa);
                string nameb = matchb.Groups["name"].Value;
                int indexb = 0;
                int subindexb = 0;
                Boolean isBindexInt = int.TryParse(matchb.Groups["index"].Value, out indexb);
                Boolean isBsubindexInt = int.TryParse(matchb.Groups["subindex"].Value, out subindexb);
                results = namea.CompareTo(nameb);
                if (results == 0)
                {
                    results = isAindexInt.CompareTo(isBindexInt);
                    if (results == 0)
                    {
                        results = indexa.CompareTo(indexb);
                        if (results == 0)
                        {
                            results = isAsubindexInt.CompareTo(isBsubindexInt);
                            if (results == 0)
                            {
                                results = subindexa.CompareTo(subindexb);
                            }
                        }
                    }
                }
                return results;
            }
        }
    }
