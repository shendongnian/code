    struct Test1
    {
        public int X;
        public int Y;
        public override string ToString()
        {
            return $"X={X}, Y={Y}";
        }
    }
    struct Test2
    {
        public int X;
        public int Y;
        public int Z;
        public override string ToString()
        {
            return $"X={X}, Y={Y}, Z={Z}";
        }
    }
    ...
    var         test1 = new Test1[100];
    Span<Test2> test2 = MemoryMarshal.Cast<Test1, Test2>(test1);
    test1[1].X = 1;
    test1[1].Y = 2;
    Console.WriteLine(test1[1]); // Prints X=1, Y=2
    test2[0].Z = 10; // Actually sets test1[1].X.
    Console.WriteLine(test1[1]); // Prints X=10, Y=2
