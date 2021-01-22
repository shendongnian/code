       internal static class CONST
       {
          internal static Regex linarize_regex = new Regex(@"[\r\n]+[\x20\t]*", RegexOptions.CultureInvariant | RegexOptions.Compiled);
          internal static Regex tag_linarize_regex = new Regex(@"(?<tag><[^>]*?>)[\r\n]+[\x20\t]*", RegexOptions.CultureInvariant | RegexOptions.Compiled);
       }
       internal static class UTILS
       {
          internal static string linarize_html(string html)
          {
             try
                {
                   html = CONST.tag_linarize_regex.Replace(html, "${tag}");
                   html = CONST.linarize_regex.Replace(html, " ");
                   return html;
                }
                catch (Exception)
                {
                   return html;
                }
          }
       }
