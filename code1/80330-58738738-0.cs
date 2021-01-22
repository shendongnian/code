        public static void WhiteSpaceReduce()
        {
            string t1 = "a b   c d";
            string t2 = "a b\n\nc\nd";
            Regex whiteReduce = new Regex(@"(?<firstWS>\s)(?<repeatedWS>\k<firstWS>+)");
            Console.WriteLine("{0}", t1);
            //Console.WriteLine("{0}", whiteReduce.Replace(t1, x => x.Value.Substring(0, 1))); 
            Console.WriteLine("{0}", whiteReduce.Replace(t1, @"${firstWS}"));
            Console.WriteLine("\nNext example ---------");
            Console.WriteLine("{0}", t2);
            Console.WriteLine("{0}", whiteReduce.Replace(t2, @"${firstWS}"));
            Console.WriteLine();
        }
