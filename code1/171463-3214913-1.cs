    public static InlineCollection GetInlines(this TextElement element)
    {
        Func<object, InlineCollection> f = GetCachedInlinesFunction(element.GetType());
        if (f != null)
            return f(element);
        else
            return null;
    }
