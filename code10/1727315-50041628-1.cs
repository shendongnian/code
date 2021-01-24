    public class MyClass
    {
        public int Length { get { return Data == null ? 0 : Data.Length; } }
        public int[] Data { get; private set; }
        public MyClass(int dataLength)
        {
            Data = new int[dataLength];
        }
    }
