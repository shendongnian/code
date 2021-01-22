     public static string StripHTML(string HTMLText, bool decode = true)
            {
                Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                var stripped = reg.Replace(HTMLText, "");
                return decode ? HttpUtility.HtmlDecode(stripped) : stripped;
            }
