    public void ProcessRequest(HttpContext context)
    {
        using (var reader = new StreamReader(context.Request.InputStream))
        {
            string postedData = reader.ReadToEnd();
            // Look what's inside postedData variable and parse it.
            // If you have problems parsing it you could post the value
            // because I didn't understand from your description how exactly
            // it will be formated.
        }
    }
