        Type type = typeof(YourClass);
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance);
        bool passesTest = true;
        foreach (PropertyInfo property in properties)
        {
            passesTest = passesTest && property.CanWrite;
        }
