    private static void PrintAllProperties(object obj)
    {
        obj.GetType().
            GetProperties().
            ToList().
            ForEach(p => 
                Console.WriteLine("{0} [{1}]", p.Name, p.PropertyType.ToString()
                ));
    }
