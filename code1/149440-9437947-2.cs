    public static string DumpToHtmlString<T>(this T objectToSerialize)
    {
        string strHTML = "";
        try
        {
            var writer = LINQPad.Util.CreateXhtmlWriter(true);
            writer.Write(objectToSerialize);
            strHTML = writer.ToString();
        }
        catch (Exception exc)
        {
            Debug.Assert(false, "Investigate why ?" + exc);
        }
        return strHTML;
    }
