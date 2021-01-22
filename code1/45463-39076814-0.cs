     public static object CreatePrivateClassInstance(string typeName, object[] parameters)
        {
            Type type = AppDomain.CurrentDomain.GetAssemblies().
                     SelectMany(assembly => assembly.GetTypes()).FirstOrDefault(t => t.Name == typeName);
            return type.GetConstructors()[0].Invoke(parameters);
        }
