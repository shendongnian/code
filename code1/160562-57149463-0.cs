    I came across this problem in a coding challenge where you have to convert 32 digit decimal to binary and find the possible combination of the substring. `using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Numerics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
        class Program
        {
    
            public static void Main()
            {
                int numberofinputs = int.Parse(Console.ReadLine());
                List<BigInteger> inputdecimal = new List<BigInteger>();
                List<string> outputBinary = new List<string>();
    
    
                for (int i = 0; i < numberofinputs; i++)
                {
                    inputdecimal.Add(BigInteger.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
                }
                //processing begins 
    
                foreach (var n in inputdecimal)
                {
                    string binary = (binaryconveter(n));
                    subString(binary, binary.Length);
                }
    
                foreach (var item in outputBinary)
                {
                    Console.WriteLine(item);
                }
    
                string binaryconveter(BigInteger n)
                {
                    int i;
                    StringBuilder output = new StringBuilder();
                    
                    for (i = 0; n > 0; i++)
                    {
                        output = output.Append(n % 2);
                        n = n / 2;
                    }
    
                    return output.ToString();
                }
    
                void subString(string str, int n)
                {
                    int zeroodds = 0;
                    int oneodds = 0;
    
                    for (int len = 1; len <= n; len++)
                    {
    
                        for (int i = 0; i <= n - len; i++)
                        {
                            int j = i + len - 1;
    
                            string substring = "";
                            for (int k = i; k <= j; k++)
                            {
                                substring = String.Concat(substring, str[k]);
    
                            }
                            var resultofstringanalysis = stringanalysis(substring);
                            if (resultofstringanalysis.Equals("both are odd"))
                            {
                                ++zeroodds;
                                ++oneodds;
                            }
                            else if (resultofstringanalysis.Equals("zeroes are odd"))
                            {
                                ++zeroodds;
                            }
                            else if (resultofstringanalysis.Equals("ones are odd"))
                            {
                                ++oneodds;
                            }
    
                        }
                    }
                    string outputtest = String.Concat(zeroodds.ToString(), ' ', oneodds.ToString());
                    outputBinary.Add(outputtest);
                }
    
                string stringanalysis(string str)
                {
                    int n = str.Length;
    
                    int nofZeros = 0;
                    int nofOnes = 0;
    
                    for (int i = 0; i < n; i++)
                    {
                        if (str[i] == '0')
                        {
                            ++nofZeros;
                        }
                        if (str[i] == '1')
                        {
                            ++nofOnes;
                        }
    
                    }
                    if ((nofZeros != 0 && nofZeros % 2 != 0) && (nofOnes != 0 && nofOnes % 2 != 0))
                    {
                        return "both are odd";
                    }
                    else if (nofZeros != 0 && nofZeros % 2 != 0)
                    {
                        return "zeroes are odd";
                    }
                    else if (nofOnes != 0 && nofOnes % 2 != 0)
                    {
                        return "ones are odd";
                    }
                    else
                    {
                        return "nothing";
                    }
    
    
                }
    
    
                Console.ReadKey();
    
            }
    
        }
    }
    
    
    
    
    
    
    
    
    `
