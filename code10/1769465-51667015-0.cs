    public static string GetDescription(Type t) {
        return TypeDescriptor.GetAttributes(t)
            .OfType<DescriptionAttribute>()
            .Select(x => x.Description)
            .FirstOrDefault();
    }
