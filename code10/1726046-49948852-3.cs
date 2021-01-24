    public static string[] SplitExtract(this string src, string delim, int pos, int count = 1) {
        var ans = new List<string>();
        var startCharPos = 0;
        for (; pos > 0; --pos) {
            var tmpPos = src.IndexOf(delim, startCharPos + 1);
            if (tmpPos >= 0)
                startCharPos = tmpPos + delim.Length;
            else {
                startCharPos = src.Length;
                break;
            }
        }
        for (; count > 0 && startCharPos < src.Length; --count) {
            var nextDelimPos = src.IndexOf(delim, startCharPos);
            if (nextDelimPos < 0)
                nextDelimPos = src.Length;
            ans.Add(src.Substring(startCharPos, nextDelimPos - startCharPos));
            startCharPos = nextDelimPos + delim.Length;
        }
        return ans.ToArray();
    }
