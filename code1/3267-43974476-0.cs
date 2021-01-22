    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                                     "001-005/015",
                                     "009/015"
                                 };
                foreach (string input in inputs)
                {
                    List<int> numbers = new List<int>();
                    string[] strNums = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string strNum in strNums)
                    {
                        if (strNum.Contains("-"))
                        {
                            int startNum = int.Parse(strNum.Substring(0, strNum.IndexOf("-")));
                            int endNum = int.Parse(strNum.Substring(strNum.IndexOf("-") + 1));
                            for (int i = startNum; i <= endNum; i++)
                            {
                                numbers.Add(i);
                            }
                        }
                        else
                            numbers.Add(int.Parse(strNum));
                    }
                    Console.WriteLine(string.Join(",", numbers.Select(x => x.ToString())));
                }
                Console.ReadLine();
            }
        }
    }
