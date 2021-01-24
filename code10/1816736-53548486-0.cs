    public static void Main(string[] args)
            {
                NormalTest();
                SpanTest();
    
                Console.ReadKey();
            }
    
            private static void NormalTest()
            {
                string test = "";
                var startDate = DateTime.Now;
                Console.WriteLine(startDate.ToString("hh:mm:ss:fff"));
                for (int i = 0; i < 250000; i++)
                {
                    test += i.ToString();
                }
    
                var endDate = DateTime.Now;
                Console.WriteLine(endDate.ToString("hh:mm:ss:fff"));
    
                Console.WriteLine("__________");
    
                Console.WriteLine($"Done in { (endDate - startDate).TotalSeconds} sec");
            }
    
            private static void SpanTest()
            {
                Span<string> test = new Span<string>(new []{""});
                var startDate = DateTime.Now;
                Console.WriteLine(startDate.ToString("hh:mm:ss:fff"));
                for (int i = 0; i < 250000; i++)
                {
                    test.Fill(i.ToString());
                }
    
                var endDate = DateTime.Now;
                Console.WriteLine(endDate.ToString("hh:mm:ss:fff"));
    
                Console.WriteLine("__________");
    
                Console.WriteLine($"Done in { (endDate - startDate).TotalSeconds} sec");
            }
