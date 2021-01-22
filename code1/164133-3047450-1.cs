    public static TagBuilder Table(....)
    {
        ...
        return tag;
    }
    
    // In the view
    <%: Html.Table(someParams).AddCssClass("fancy") %>
