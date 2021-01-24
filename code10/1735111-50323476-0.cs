        internal interface IProcess
        {
            void Process();
        }
        class AA
        {
        }
        class BB : AA, IProcess
        {
            public void Process() { Console.WriteLine($"Inside: {nameof(BB)}"); }
        }
        class CC : AA, IProcess
        {
            public void Process() { Console.WriteLine($"Inside: {nameof(CC)}"); }
        }
        class DD : AA, IProcess
        {
            public void Process() { Console.WriteLine($"Inside: {nameof(DD)}"); }
        }
