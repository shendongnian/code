    public static int? GetProperty<T>(T obj) where T : class
    {
        bool isBook = (obj is Book);
        if(isBook)
        {
            var bookObj = (obj as Book);
            return ((bookObj != null) ? bookObj.Isbn : null);
        }
        return null;
    }
