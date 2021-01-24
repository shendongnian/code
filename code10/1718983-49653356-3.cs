    public struct MySpan<T>
    {
        public int Length { get; }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            MySpan<char> s1;
            var l1 = s1.Length;
        }
    }
