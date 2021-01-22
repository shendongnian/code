    public static string DateTimeOrEmpty(this HtmlHelper htmlHelper, DateTime dateTime, string format)
    {
        return (dateTime == DateTime.MinValue)
            ? String.Empty 
            : dateTime.ToString(format);
    }
