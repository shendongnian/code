     public static class HtmlContentExtensions
     {
         public static string ToHtmlString(this IHtmlContent htmlContent)
         {
             using (var writer = new StringWriter())
             {
                 htmlContent.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                 return writer.ToString();
             }
         }
      }
