    /// <summary>
    /// Gets the <see cref="MediaTypeFormatter"/> to use for Json.
    /// </summary>
    public JsonMediaTypeFormatter JsonFormatter
    {
        get { return Items.OfType<JsonMediaTypeFormatter>().FirstOrDefault(); }
    }
    
