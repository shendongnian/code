    // mangled code horribly to fit without scrolling
    public static class CsvSplitter
    {
        public static string[] SplitWithQualifier(this string text,
                                                  char delimiter,
                                                  char qualifier,
                                                  bool stripQualifierFromResult)
        {
            string pattern = string.Format(
                @"{0}(?=(?:[^{1}]*{1}[^{1}]*{1})*(?![^{1}]*{1}))",
                Regex.Escape(delimiter.ToString()),
                Regex.Escape(qualifier.ToString())
            );
            
            string[] split = Regex.Split(text, pattern);
            if (stripQualifierFromResult)
                return split.Select(s => s.Trim().Trim(qualifier)).ToArray();
            else
                return split;
        }
    }
