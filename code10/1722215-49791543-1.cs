    using System.Text.RegularExpressions;    
    namespace ReplaceExample
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine(Regex.Replace("1234,2345,12341,6442", @"12341[,]*", string.Empty));
            }
        }
    }
