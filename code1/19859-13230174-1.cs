        /// <summary>
        /// Trims the ignoring spacified tags
        /// </summary>
        /// <param name="text">the text from which html is to be removed</param>
        /// <param name="isRemoveScript">specify if you want to remove scripts</param>
        /// <param name="ignorableTags">specify the tags that are to be ignored while stripping</param>
        /// <returns>Stripped Text</returns>
        public static string StripHtml(string text, bool isRemoveScript, params string[] ignorableTags)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace("&lt;", "<");
                text = text.Replace("&gt;", ">");
                string ignorePattern = null;
                if (isRemoveScript)
                {
                    text = Regex.Replace(text, "<script[^<]*</script>", string.Empty, RegexOptions.IgnoreCase);
                }
                foreach (string tag in ignorableTags)
                {
                    if (tag.Equals("b"))
                    {
                        text = text.Replace("<b>", "<strong>");
                        text = text.Replace("</b>", "</strong>");
                        if (ignorableTags.Contains("strong"))
                        {
                            ignorePattern = string.Format("{0}(?!strong)", ignorePattern);
                        }
                    }
                    else
                    {
                        ignorePattern = string.Format("{0}(?!{1})", ignorePattern, tag);
                    }
                }
                ignorePattern = string.Format(@"<{0}[^>]*>", ignorePattern);
                text = Regex.Replace(text, ignorePattern, "", RegexOptions.IgnoreCase);
                text = text.Replace("\"", @"&#34;");
                text = text.Replace("<", @"&#60;");
                text = text.Replace(">", @"&#62;");
            }
            return text;
        }
