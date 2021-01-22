            object obj = new string[] { "abc", "def" };
            Type type = null;
            foreach (Type iType in obj.GetType().GetInterfaces())
            {
                if (iType.IsGenericType && iType.GetGenericTypeDefinition()
                    == typeof(IEnumerable<>))
                {
                    type = iType.GetGenericArguments()[0];
                    break;
                }
            }
            if (type != null) Console.WriteLine(type);
