    public static string EscapeAlertMessage(string value)
    {
        value = value.Replace("\\", "\\\\");
        value = value.Replace("'", "\\'");
        value = value.Replace("\"", "\\\"");
        return value;
    }
