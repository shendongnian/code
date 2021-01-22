    namespace Flags
    {
        class Program
        {
            [Flags]
            public enum MyFlags : short
            {
                Foo = 0x1,
                Bar = 0x2,
                Baz = 0x4
            }
    
            static void Main(string[] args)
            {
                MyFlags fooBar = MyFlags.Foo | MyFlags.Bar;
    
                if ((fooBar & MyFlags.Foo) == MyFlags.Foo)
                {
                    Console.WriteLine("Item has Foo flag set");
                }
            }
        }
    }
