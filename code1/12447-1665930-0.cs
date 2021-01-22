    public static class EnumExtension
        {
            public static int Max(this Enum enumType)
            {           
                return Enum.GetValues(enumType.GetType()).Cast<int>().Max();             
            }
        }
        class Program
        {
            enum enum1 { one, two, second, third };
            enum enum2 { s1 = 10, s2 = 8, s3, s4 };
            enum enum3 { f1 = -1, f2 = 3, f3 = -3, f4 };
    
            static void Main(string[] args)
            {
                Console.WriteLine(enum1.one.Max());        
            }
    }
