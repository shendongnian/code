    public static string Table(...., string @class)
    {
        ...
        sb.AppendFormat("class='{0}", @class);
        ...
    }
    
    // In the view
    <%: Html.Table(someParams, "fancy") %>
