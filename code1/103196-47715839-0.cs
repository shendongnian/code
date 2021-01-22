    internal static class UTILS
    {
       internal static string linarize_html(string html)
       {
          return Regex.Replace(html, @"[\r\n]+[\x20\t]*", String.Empty, RegexOptions.Compiled);
       }
    }
