    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test1();
                Console.ReadKey();
            }
    
            public static void Test1()
            {
                List<List<String>> list = new List<List<string>>() { 
                    new List<String>() { "XYZ", "ABC","100" },
                    new List<String>() { "X", "ABC", "100"},
                };
    
                string text = "", a = "", b = "", c = "";
                for (int i = 0; i < list.Count; i++)
                {
                    a = list[i][0];
                    b = list[i][1];
                    c = list[i][2];
                    text += String.Format("{0, -8} {1,-4} {2,8}{3}", a, b, c, Environment.NewLine);
                }
                Console.WriteLine(text);
            }
        }
    }
