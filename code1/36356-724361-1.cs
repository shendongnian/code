    StringBuilder html = new StringBuilder();
    html.Append("<span");
    html.Append(" id=\"someId\"");
    if (!string.IsNullOrEmpty(cssClass)) html.AppendFormat(" class=\"{0}\"", HttpUtility.HtmlAttributeEncode(cssClass));
    html.Append(HttpUtility.HtmlEncode(text));
    html.Append(">");
