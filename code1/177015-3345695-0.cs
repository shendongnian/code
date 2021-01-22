    class C { public string S { get; set; } }
    class D
    {
        private static C c = new C();
        static C M()
        {
            Console.WriteLine("hello!");
            return c;
        }
    }
