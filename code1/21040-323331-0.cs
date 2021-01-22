    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace CamelCaseToString
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(CamelCaseToString("ThisIsYourMasterCallingYou"));   
            }
            private static string CamelCaseToString(string str)
            {
                if (str == null || str.Length == 0)
                    return null;
                StringBuilder retVal = new StringBuilder(32);
                retVal.Append(str[0]);
                for (int i = 1; i < str.Length; i++ )
                {
                    if (char.IsLower(str[i]))
                    {
                        retVal.Append(str[i]);
                    }
                    else
                    {
                        retVal.Append(" ");
                        retVal.Append(char.ToLower(str[i]));
                    }
                }
                return retVal.ToString();
            }
        }
    }
