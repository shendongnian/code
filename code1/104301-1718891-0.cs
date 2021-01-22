    private string[] GetPublicStringProperties()
    {
        return this.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(pi => pi.PropertyType == typeof(string))
            .Select(pi => pi.Name)
            .ToArray();
    }
