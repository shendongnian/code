        public class Program
        {
            public static void Main(string[] args)
            {
                var input = "foo\"bar\"";
                var pattern = new Regex(@"(?<=)""(?<word>\w+)""", RegexOptions.ExplicitCapture);
                var count = 0;
                var output = pattern.Replace(input, m=>
                                             {
                                                 var str = m.Groups["word"].Value;
                                                 count+=str.Length;
                                                 return str;
                                             });
                Console.WriteLine("output: {0}; count: {1}.", output, count);
                //will print - output: foobar; count: 3.
            }
        }
