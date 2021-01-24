    namespace PasswordGen
    {
        public class Program
        {
            private static Random _random = new Random();
    
            static void Main(string[] args)
            {
                var nonAlphaSymbols = "1234567890!@#$%&?";
                var password = new[] { (char)_random.Next('A', 'Z' + 1) } // upper case character
                    .Concat(Enumerable.Range(0, 10).Select(a => (char)_random.Next('a', 'z' + 1)) // 10 lower case
                    .Concat(Enumerable.Range(0, 4).Select(a => nonAlphaSymbols[_random.Next(0, nonAlphaSymbols.Length)]))) // 4 from nonAlpha
                    .Shuffle(); // optional, if you want to shuffle the outcome
    
                Console.WriteLine(new string(password.ToArray()));
            }
    
        }
    
        public static class Extensions
    	{	
    		private static Random _random = new Random();
    
            public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> input)
            {
                List<T> output = new List<T>(input);
                for (int i = 0; i < output.Count; i++)
                {
                    var swapTarget = _random.Next(i, output.Count - 1);
                    T temp = output[swapTarget];
                    output[swapTarget] = output[i];
                    output[i] = temp;
                }
                return output;
            }
        }
    }
