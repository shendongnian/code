    /// <summary>
    /// Checks the Request.QueryString for the specified value and returns it, if none 
    /// is found then the default value is returned instead
    /// </summary>
    public static T QueryValue<T>(this HtmlHelper helper, string param, T defaultValue) {
        object value = HttpContext.Current.Request.QueryString[param] as object;
        if (value == null) { return defaultValue; }
        try {
            return (T)Convert.ChangeType(value, typeof(T));
        } catch (Exception) {
            return defaultValue;
        }
    }
