    class Extension
        {
            static void Main(string[] args)
            {
                string s = "sudhakar";
                Console.WriteLine(s.GetWordCount());
                Console.ReadLine();
            }
     
        }
        public static class MyMathExtension
        {
     
            public static int GetWordCount(this System.String mystring)
            {
                return mystring.Length;
            }
        }
