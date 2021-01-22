     public static string StripHTML(string HTMLText)
            {
                Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                return reg.Replace(HTMLText, "");
            }
