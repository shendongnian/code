    struct Test
    {
        public int X;
        public int Y;
        public override string ToString()
        {
            return $"X={X}, Y={Y}";
        }
    }
    ...
    var testArray = new Test[100];
    Span<long> longArray = MemoryMarshal.Cast<Test, long>(testArray);
    testArray[0].X = 1;
    testArray[0].Y = 2;
    Console.WriteLine(testArray[0]); // Prints X=1, Y=2
    longArray[0] = 0x0000000300000004;
    Console.WriteLine(testArray[0]); // Prints X=4, Y=3
