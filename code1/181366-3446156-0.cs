    public static string GetLogFor(object target)
    {
        var properties =
            from property in target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            select new
            {
                Name = property.Name,
                Value = property.GetValue(target, null)
            };
        var builder = new StringBuilder();
        foreach(var property in properties)
        {
            builder.Append(property.Name).Append(" = ").AppendLine(property.Value);
        }
        return builder.ToString();
    }
