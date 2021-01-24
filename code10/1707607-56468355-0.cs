    public interface IIntContainer
    {
        int Value { get; }
    }
    public struct LargeStruct : IIntContainer
    {
        public int val0;
        public int val1;
        // ... lots of other fields
        public int val20;
        public int Value => val0;
    }
    public class SmallClass : IIntContainer
    {
        public int val0;
        public int Value => val0;
    }
    public static class Program
    {
        static void Main()
        {
            DoSomethingWithValue(new LargeStruct());
            DoSomethingWithValue(new SmallClass());
        }
        public static void DoSomethingWithValue<T>(in T container) where T : IIntContainer
        {
            int value = container.Value;
            // Do something with value...
        }
    }
