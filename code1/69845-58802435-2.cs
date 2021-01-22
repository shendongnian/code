            public static void Main()
            {
                Thread.SetData(Thread.GetNamedDataSlot("memory"), "before passing");
                var n = Thread.GetData(Thread.GetNamedDataSlot("memory"));
                Console.WriteLine(n);
                TestI("after passing");
                Console.WriteLine(n);
            }
        
            public static void TestI(string  text)
            {
                Thread.SetData(Thread.GetNamedDataSlot("memory"), text);
            }
        }
