    public static class HtmlUtilsExtensions
    {
      public static HtmlHelper BeginTable(this HtmlHelper htmlHelper)
      {
        return htmlHelper.ViewContext.Writer.Write("<table>");
      }
      public static HtmlHelper NewRow(HtmlHelper htmlHelper)
      {
         return htmlHelper.ViewContext.Writer.Write("<tr><td>");
      }
       public static HtmlHelper NewColumn(HtmlHelper htmlHelper, string CssClass)
       {
        return htmlHelper.ViewContext.Writer.Write(string.Format("</td><td class=\"{0}\">", CssClass));
       }
       public static HtmlHelper EndRow(HtmlHelper htmlHelper)
       {
        return htmlHelper.ViewContext.Writer.Write("</td></tr>");
       }
       public static HtmlHelper EndTable(HtmlHelper htmlHelper)
      {
        return htmlHelper.ViewContext.Writer.Write("</table>");
      }       
