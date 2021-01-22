    class MilanTest
    { 
        public int SomeValue { get; set; }
    }
    class Test
    {
        static void RefValTest(MilanTest x)
        { 
            x.SomeValue = 5;
        }
        static void Main()
        {
            MilanTest t = new MilanTest();
            RefValTest(t);
            Console.WriteLine(t.SomeValue); // Prints 5
        }
    }
