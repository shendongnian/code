    var allowedTags = new[] { "a", "abbr", "br", /* etc. */ };
    var output = Regex.Replace(input,
        // Matches a single start or end tag
        @"</?(\w+)[^>]*>",
        // If the tag is one of the allowed tags...
        me => allowedTags.Contains(me.Groups[1].Value)
            // ... keep it unchanged
            ? me.Value
            // otherwise, HTML-encode it
            : HttpServerUtility.HtmlEncode(me.Value),
        RegexOptions.Singleline);
