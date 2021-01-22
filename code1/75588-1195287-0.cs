        interface I1 { int NumberOne { get; set; } }
        interface I2 { int NumberTwo { get; set; } }
        static void DoSomething<T>(T item) where T : I1
        {
            Console.WriteLine(item.NumberOne);
        }
        static void DoSomething<T>(T item) where T : I2
        {
            Console.WriteLine(item.NumberTwo);
        }
