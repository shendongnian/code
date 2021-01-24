    private static string GetValue(IShellProperty value)
    {
        if (value == null || value.ValueAsObject == null)
        {
            return String.Empty;
        }
        return value.ValueAsObject.ToString();
    }
