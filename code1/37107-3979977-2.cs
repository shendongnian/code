    public string HackXPath(string xpath_, string prefix_)
    {
        return System.Text.RegularExpressions.Regex.Replace(xpath_, @"(^(?![A-Za-z0-9\-\.]+::)|[A-Za-z0-9\-\.]+::|[@|/|\[])(?'Expression'[A-Za-z][A-Za-z0-9\-\.]*)", x =>
                    {
                        int expressionIndex = x.Groups["Expression"].Index - x.Index;
                        string before = x.Value.Substring(0, expressionIndex);
                        string after = x.Value.Substring(expressionIndex, x.Value.Length - expressionIndex);
                        return String.Format("{0}{1}:{2}", before, prefix_, after);
                    });
    }
