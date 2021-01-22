    using System;
    using System.Text;
    namespace SpringTest3
    {
        static class Extentions
        {
            static private StringBuilder ReverseStringImpl(string s, int pos, StringBuilder sb)
            {
                return (s.Length <= --pos || pos < 0) ? sb : ReverseStringImpl(s, pos, sb.Append(s[pos]));
            }
    
            static public string Reverse(this string s)
            {
                return ReverseStringImpl(s, s.Length, new StringBuilder()).ToString();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("abc".Reverse());
            }
        }
    }
