    public static void RenderPartialIfInRole
        (this HtmlHelper html, string control, string role)
    {
        if (HttpContext.Current.User.IsInRole(role)
            html.RenderPartial(control);
    }
