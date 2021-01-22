    public enum MyEnum
    {
        MY_VALUE = 'm'
    }
    
    public static class MyExtensions
    {
        public static char GetChar(this Enum value)
        {
            return (char)value.GetHashCode();
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            MyEnum me = MyEnum.MY_VALUE;
            Console.WriteLine(me + " = " + me.GetChar());
        }
    }
