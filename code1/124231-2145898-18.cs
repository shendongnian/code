        static void Main(string[] args) {
            int minChars = 3;
            int maxChars = 13;
            int testSetSize = 5000;
            DateTime start = DateTime.Now;
            foreach (string testStr in
                GenerateTest(minChars, maxChars, testSetSize)) {
                IsAlphaNumeric(testStr);
            }
            Console.WriteLine("My solution : {0}", (DateTime.Now - start).ToString());
            start = DateTime.Now;
            foreach (string testStr in
                GenerateTest(minChars, maxChars, testSetSize)) {
                DarinDimitrovSolution.IsAlphaAndNumeric_0(testStr);
            }
            Console.WriteLine("DarinDimitrov  1 : {0}", (DateTime.Now - start).ToString());
            start = DateTime.Now;
            foreach (string testStr in
                GenerateTest(minChars, maxChars, testSetSize)) {
                DarinDimitrovSolution.IsAlphaAndNumeric_1(testStr);
            }
            Console.WriteLine("DarinDimitrov(compiled) 2 : {0}", (DateTime.Now - start).ToString());
            Console.ReadKey();
        }
