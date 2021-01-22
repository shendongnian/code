      private string GetFirstParagraph(string htmltext)
            {
                Match m = Regex.Match(htmltext, @"<p>\s*(.+?)\s*</p>");
                if (m.Success)
                {
                    return m.Groups[1].Value;
                }
                else
                {
                    return htmltext;
                }
            }
