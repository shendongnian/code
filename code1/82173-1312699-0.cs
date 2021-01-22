    public static string FormatObject(object obj)
    {
        if (obj is DateTime)
            return ((DateTime)obj).ToString("MMM dd yyyy");
        else if (obj is float || obj is double)
            return (obj as IFormattable).ToString("0.0", new System.Globalization.NumberFormatInfo());
        else return obj.ToString();
    }
