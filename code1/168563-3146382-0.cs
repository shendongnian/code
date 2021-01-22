        private static readonly Regex rxDivTag = new Regex(
            @"<(?<close>/)?div(\s[^>]*?)?(?<selfClose>/)?>",
            RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        private const string RXCAP_DIVTAG_CLOSE = "close";
        private const string RXCAP_DIVTAG_SELFCLOSE = "selfClose";
        private static List<string> GetProductDivs(string pageText, int start)
        {
            bool success = true;
            int curr = start + 1;
            for (Match matchNextTag = rxDivTag.Match(pageText, curr) ; depth > 0 ; matchNextTag = rxDivTag.Match(pageText, curr))
            {
                if (matchNextTag == Match.Empty)
                {
                    success = false;
                    break;
                }
                if (matchNextTag.Groups[RXCAP_DIVTAG_CLOSE].Success)
                {
                    if (matchNextTag.Groups[RXCAP_DIVTAG_SELFCLOSE].Success)
                    {
                        success = false;
                        break;
                    }
                    --depth;
                }
                else if (!matchNextTag.Groups[RXCAP_DIVTAG_SELFCLOSE].Success)
                {
                    ++depth;
                }
                curr = matchNextTag.Index + matchNextTag.Length;
            }
            if (success)
            {
                return pageText.Substring(start, curr - start);
            }
            else
            {
                return null;
            }
        }
