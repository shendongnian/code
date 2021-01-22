    class Program
    {
        public int Foo { get; set; }
        public void Bar(out int x)
        {
            x = 5;
        }
        void Run()
        {
            Bar(out Foo); // compile error 
        }
        static void Main()
        {
            new Program().Run();
        }
    }
