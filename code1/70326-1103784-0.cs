        Assembly assembly = typeof(DataSet).Assembly; // etc
        foreach (Type type in assembly.GetTypes())
        {
            if (type.BaseType == null)
            {
                Console.WriteLine(type.Name);
            }
            else
            {
                Console.WriteLine(type.Name + " : " + type.BaseType.Name);
            }
        }
