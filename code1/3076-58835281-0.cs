        public static string GenerateUrl(string Url)
        {
            string UrlPeplaceSpecialWords = Regex.Replace(Url, @"&quot;|['"",&?%\.!()@$^_+=*:#/\\-]", " ").Trim();
            string RemoveMutipleSpaces = Regex.Replace(UrlPeplaceSpecialWords, @"\s+", " ");
            string ReplaceDashes = RemoveMutipleSpaces.Replace(" ", "-");
            string DuplicateDashesRemove = ReplaceDashes.Replace("--", "-");
            return DuplicateDashesRemove.ToLower();
        }
