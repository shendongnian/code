    static void Log(object @object)
    {
        foreach (var property in @object.GetType().GetProperties())
            Console.WriteLine(property.Name + ": " + property.GetValue(@object, null).ToString());
    }
