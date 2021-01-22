        object list = new List<int>();
        Type type = list.GetType();
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
        {
            Console.WriteLine("is a List-of-" + type.GetGenericArguments()[0].Name);
        }
