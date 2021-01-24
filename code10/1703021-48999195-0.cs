    public static string TrimOutside(this string src, string openDelims, string closeDelims) {
        if (!String.IsNullOrEmpty(src)) {
            var openIndex = openDelims.IndexOf(src[0]);
            if (openIndex >= 0 && src.EndsWith(closeDelims.Substring(openIndex, 1)))
                src = src.Substring(1, src.Length - 2);
        }
        return src;
    }
