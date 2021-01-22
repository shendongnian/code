    using System.Web.UI;
    public static string RenderToString(this Control control)
    {
        var sb = new StringBuilder();
        using (var sw = new StringWriter(sb))
        using (var textWriter = new HtmlTextWriter(sw))
        {
            control.RenderControl(textWriter);
        }
        return sb.ToString();
    }
