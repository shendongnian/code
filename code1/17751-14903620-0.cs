    public string ExtractReply(string text, string address)
    {
        var regexes = new List<Regex>() { new Regex("From:\\s*" + Regex.Escape(address), RegexOptions.IgnoreCase),
                            new Regex("<" + Regex.Escape(address) + ">", RegexOptions.IgnoreCase),
                            new Regex(Regex.Escape(address) + "\\s+wrote:", RegexOptions.IgnoreCase),
                            new Regex("\\n.*On.*(\\r\\n)?wrote:\\r\\n", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                            new Regex("-+original\\s+message-+\\s*$", RegexOptions.IgnoreCase),
                            new Regex("from:\\s*$", RegexOptions.IgnoreCase),
                            new Regex("^>.*$", RegexOptions.IgnoreCase | RegexOptions.Multiline)
                        };
    
        var index = text.Length;
    
        foreach(var regex in regexes){
            var match = regex.Match(text);
    
            if(match.Success && match.Index < index)
                index = match.Index;
        }
    
        return text.Substring(0, index).Trim();
    }
