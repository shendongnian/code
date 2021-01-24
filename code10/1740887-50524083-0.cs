    namespace Demo
    {
        interface IOne { }
        class Zero { }
        class One : IOne { }
        class Two : One { }
        class Three : Zero, IOne { }
        public static class TypeExt
        {
            public static bool IsSubInterface(this Type t1, Type t2)
            {
                if (!t2.IsAssignableFrom(t1))
                    return false;
                if (t1.BaseType == null)
                    return true;
                return !t2.IsAssignableFrom(t1.BaseType);
            }
        }
        class Program
        {
            static void Main()
            {
                Console.WriteLine(typeof(Three).IsSubInterface(typeof(IOne)));
                Console.WriteLine(typeof(Two).IsSubInterface(typeof(IOne)));
            }
        }
    }
