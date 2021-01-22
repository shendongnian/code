    public static MyHtmlTag GenerateTag<T> (this HtmlHelper helper, T obj) where T : MyHtmlTag, new()
    {
        T val = new T ();
        return val;
    }
