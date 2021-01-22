        static string ReplaceQuoteTags(string input)
        {
            const string closeTag = @"[/quote]";
            const string pattern = @"\[quote=(.*?)\|(\d+?)\](.*?)\[/quote\]"; //or whatever you prefer
            const string replacement = @"<div class=""quote"">{0}<div><a href=""users/details/{1}"">{2}</a></div></div>";
            
            int searchStartIndex = 0;
            int closeTagIndex = input.IndexOf(closeTag, StringComparison.OrdinalIgnoreCase);
            while (closeTagIndex > -1)
            {
                Regex r = new Regex(pattern, RegexOptions.RightToLeft | RegexOptions.IgnoreCase);
                bool found = false;
                input = r.Replace(input,
                    x =>
                    {
                        found = true;
                        return string.Format(replacement, x.Groups[3], x.Groups[2], x.Groups[1]);
                    }
                    , 1, closeTagIndex + closeTag.Length);
                if (!found)
                {
                    searchStartIndex = closeTagIndex + closeTag.Length;
                    //in case there is a close tag without a proper corresond open tag.
                }
                closeTagIndex = input.IndexOf(closeTag, searchStartIndex, StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }
