    // In your controller
    ViewData["DisableControls"] = true;
    <%-- In your view --%>
    <% bool disabled = ViewData["DisableControls"] as bool; %>
    ...
    <%= Html.TextBox("fieldname", value, disabled) %>
    <%= Html.CheckBox("anotherone", value, disabled) %>
    // In a helper class
    public static string TextBox(this HtmlHelper Html, string fieldname, object value, bool disabled)
    {
        var attributes = new Dictionary<string, string>();
        if (disabled)
            attributes.Add("disabled", "disabled");
        return Html.TextBox(fieldname, value, attributes);
    }
