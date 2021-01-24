    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        public static void Main()
        {
            var regex = new Regex(@"^[a-zA-Z\d#@][a-zA-Z\d#@\-\. ]{1,149}$");
            var rand = new Random();
            var start = new string[]{"1", "a", "#", "@", };
            var andThen = new string[]{"1", "a", "#", "@", "-", ".", " "};
    
            const int numTests = 10;
            const int testLength = 150;
    
            for (var i = 0; i < numTests; ++i)
            {
                var s = start[0];
                var builder = new StringBuilder(s);
                for (var j = 1; j < testLength; ++j)
                {
                    var r = rand.Next() % andThen.Length;
                    builder.Append(andThen[r]);
                }
    
                var test = builder.ToString();
                var isMatch = regex.IsMatch(test);
    
                Console.WriteLine($"{test} {isMatch}");
            }
        }
    }
