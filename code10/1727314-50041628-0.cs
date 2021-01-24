    public class MyClass
    {
        public readonly int Length;
        public int[] Data { get; private set; }
        public MyClass(int dataLength)
        {
            Length = dataLength;
            Data = new int[dataLength];
        }
    }
