public static T GetQueryString&lt;T>(string key)
{
    T result = default(T);
	string value = HttpContext.Current.Request.QueryString[key];
    if (!String.IsNullOrEmpty(value))
    {
        try
        {
            result = Converter.ConvertTo&lt;T>(value);  
        }
        catch
        {
            //Could not convert.  Pass back default value...
            result = default(T);
        }
    }
    return result;
}
