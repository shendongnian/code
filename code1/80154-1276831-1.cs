        foreach (Type interfaceType in type.GetInterfaces())
        {
            if (interfaceType.IsGenericType
                && interfaceType.GetGenericTypeDefinition()
                == typeof(IList<>))
            {
                Console.WriteLine("Is an IList-of-" +
                    interfaceType.GetGenericArguments()[0].Name);
            }
        }
