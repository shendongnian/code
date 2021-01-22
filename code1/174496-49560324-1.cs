    public static string ToCode(this TransactionTypeEnum val)
    {
        return GetCode(val);
    }
    private static string GetCode(object val)
    {
        var attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
