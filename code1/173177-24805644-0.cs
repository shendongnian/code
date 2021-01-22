    public static string Blah(this HtmlHelper html, object htmlAttributes)
    {
        // Create a dictionary from the object
        HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes );
    
        // ... rest of implementation
    }
