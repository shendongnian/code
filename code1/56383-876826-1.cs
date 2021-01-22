    public enum MyEnum
    {
        First = 1,
        Second = 2,
        Third = 3
    }
    
    public static class Utility
    {
        public static string Description(this Enum e)
        {
            Type t = e.GetType();
            DescriptionAttribute[] desc =
                (DescriptionAttribute[])(t.GetField(e.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false));
            return desc.Length > 0 ? desc[0].Description : e.ToString();
        }
        public static byte ToByte(this Enum ai)
        {
            object o=Enum.ToObject(ai.GetType(), ai);
            return Convert.ToByte(o);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEnum me = MyEnum.Third;
            Console.WriteLine("Value: {0}\r\nType: {1}"
            ,me.ToByte(),me.ToByte().GetType().ToString());
            Console.ReadLine();
        }
    }
