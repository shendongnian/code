        static Type GetRawType(Type type)
        {
            return type.IsGenericType ? type.GetGenericTypeDefinition() : type;
        }
        static void Main()
        {
            List<int> list1 = new List<int>();
            List<string> list2 = new List<string>();
            Type type1 = GetRawType(list1.GetType()),
                type2 = GetRawType(list2.GetType());
            Console.WriteLine(type1 == type2); // true
        }
