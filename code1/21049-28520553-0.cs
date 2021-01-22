    using System;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string piratese = "avastTharMatey";
                string ivyese = "CheerioPipPip";
    
                Console.WriteLine("{0}\n{1}\n", piratese.CamelCaseToString(), ivyese.CamelCaseToString());
                Console.WriteLine("For Pete\'s sake, man, hit ENTER!");
                string strExit = Console.ReadLine();
            }
    
        }
    
        public static class StringExtension
        {
            public static string CamelCaseToString(this string str)
            {
                StringBuilder retVal = new StringBuilder(32);
    
                if (!string.IsNullOrEmpty(str))
                {
                    string strTrimmed = str.Trim();
    
                    if (!string.IsNullOrEmpty(strTrimmed))
                    {
                        retVal.Append(char.ToUpper(strTrimmed[0]));
    
                        if (strTrimmed.Length > 1)
                        {
                            for (int i = 1; i < strTrimmed.Length; i++)
                            {
                                if (char.IsUpper(strTrimmed[i])) retVal.Append(" ");
    
                                retVal.Append(char.ToLower(strTrimmed[i]));
                            }
                        }
                    }
                }
                return retVal.ToString();
            }
        }
    }
