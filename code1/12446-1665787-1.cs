     class Program
        {
            enum enum1 { one, two, second, third };
            enum enum2 { s1 = 10, s2 = 8, s3, s4 };
            enum enum3 { f1 = -1, f2 = 3, f3 = -3, f4 };
    
            static void Main(string[] args)
            {
                TestMaxEnumValue(typeof(enum1));
                TestMaxEnumValue(typeof(enum2));
                TestMaxEnumValue(typeof(enum3));
            }
    
            static void TestMaxEnumValue(Type enumType)
            {
                Enum.GetValues(enumType).Cast<Int32>().ToList().ForEach(item =>
                    Console.WriteLine(item.ToString()));
    
                int maxValue = Enum.GetValues(enumType).Cast<int>().Max();     
                Console.WriteLine("The max value of {0} is {1}", enumType.Name, maxValue);
            }
        }
