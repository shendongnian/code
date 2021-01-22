      public static void Main()
            {
                DATA.Str = "before passing";
                Console.WriteLine(DATA.Str);
                TestI("after passing");
                Console.WriteLine(DATA.Str);
            }
            public class DATA
            {
                public static string Str { get; set; } = "";
            }
            public static void TestI(string  text)
            {
                DATA.Str = text;
            }
