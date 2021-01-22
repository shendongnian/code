    using CSScriptLibrary;
    using System;
    using System.Collections.Generic;
    namespace LinqStringTest
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var lists = new List<List<int>>() {
                    new List<int> { 0, 1, 2, 3 },
                    new List<int> { 4, 5 },
                    new List<int> { 6, 7 },
                    new List<int> { 10,11,12 },
                };
                var code = GetCode(lists);
                AsmHelper scriptAsm = new AsmHelper(CSScript.LoadCode(code));
                var result = (IEnumerable<dynamic>)scriptAsm.Invoke("Script.LinqCombine", lists);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
            private static string GetCode(List<List<int>> listsToCombine)
            {
                var froms = "";
                var selects = "";
                for (int i = 0; i < listsToCombine.Count; i++)
                {
                    froms += string.Format("from d{0} in lists[{0}]{1}", i, Environment.NewLine);
                    selects += string.Format("D{0} = d{0},", i);
                }
                return @"using System;
                  using System.Linq;
                  using System.Collections.Generic;
                  public class Script
                  {
                      public static IEnumerable<dynamic> LinqCombine(List<List<int>> lists)
                      {
                            var x = " + froms + @"
                                    select new { " + selects + @" };
                            return x;
                      }
                  }";
            }
        }
    }
