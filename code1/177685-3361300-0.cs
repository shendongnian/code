    public T GetObject<T>()
    {
        string uri = "";
        if (typeof(T) == typeof(Namespace.ExampleDataContract))
        {
            uri = "http://www.example.com/blah.json";
        }
        else if (typeof(T) == ...)
        {
            ...
        }
        else
        {
            ... // throw some exception
        }
        return JsonHelper.Deserialize<T>(this.GetJson(uri));
    }
