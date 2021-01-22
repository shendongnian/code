    using System;
    
    [Flags]
    enum Foo
    {
        A = 1,
        B = 2,
        C = 4,
        D = 8
    }
    
    class Test
    {
        public static Boolean IsEnumFlagPresent<T>(T value, T lookingForFlag) 
            where T : struct
        {
            int intValue = (int) (object) value;
            int intLookingForFlag = (int) (object) lookingForFlag;
            return ((intValue & intLookingForFlag) == intLookingForFlag);
        }
        
        static void Main()
        {
            Console.WriteLine(IsEnumFlagPresent(Foo.B | Foo.C, Foo.A));
            Console.WriteLine(IsEnumFlagPresent(Foo.B | Foo.C, Foo.B));
            Console.WriteLine(IsEnumFlagPresent(Foo.B | Foo.C, Foo.C));
            Console.WriteLine(IsEnumFlagPresent(Foo.B | Foo.C, Foo.D));
        }
    }
