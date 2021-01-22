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
                if (!ignorableTags.Contains("style"))
                {
                    text = Regex.Replace(text, "<style[^<]*</style>", string.Empty, RegexOptions.IgnoreCase);
                }
                foreach (string tag in ignorableTags)
                {
                    //the character b spoils the regex so replace it with strong
                    if (tag.Equals("b"))
                    {
                        text = text.Replace("<b>", "<strong>");
                        text = text.Replace("</b>", "</strong>");
                        if (ignorableTags.Contains("strong"))
                        {
                            ignorePattern = string.Format("{0}(?!strong)(?!/strong)", ignorePattern);
                        }
                    }
                    else
                    {
                        //Create ignore pattern fo the tags to ignore
                        ignorePattern = string.Format("{0}(?!{1})(?!/{1})", ignorePattern, tag);
                    }
                }
                //finally add the ignore pattern into regex <[^<]*> which is used to match all html tags
                ignorePattern = string.Format(@"<{0}[^<]*>", ignorePattern);
                text = Regex.Replace(text, ignorePattern, "", RegexOptions.IgnoreCase);
            }
            return text;
        }
