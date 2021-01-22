    <% 
        Html.ConditionalRenderPartial("AdminMenu", HttpContext.Current.User.IsInRole("AdminRole")); 
        Html.ConditionalRenderPartial("ApproverMenu", HttpContext.Current.User.IsInRole("ApproverRole")); 
        Html.ConditionalRenderPartial("EditorMenu", HttpContext.Current.User.IsInRole("EditorRole")); 
    %>
...
    public static void ConditionalRenderPartial
        (this HtmlHelper html, string control, bool cond)
    {
        if (cond)
            html.RenderPartial(control);
    }
