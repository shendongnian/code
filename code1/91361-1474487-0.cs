    string pattern = "(?<start>>)(?<content>.+?(?<!>))(?<end><)|(?<start>\")(?<content>.+?)(?<end>\")";
    string result = Regex.Replace(test, pattern, m =>
    			m.Groups["start"].Value +
    			HttpUtility.HtmlEncode(HttpUtility.HtmlDecode(m.Groups["content"].Value)) +
    			m.Groups["end"].Value);
    var doc = XElement.Parse(result);
