    public static String Substitute(this String template, object obj)
    {
        return Substitute(
            template,
            obj.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(obj, null))
        );
    }
