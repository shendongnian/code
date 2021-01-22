    var matches = regex.Matches(original);
    var sb = new StringBuilder(original.Length);
    int pos = 0; // position in original string
    foreach(var match in matches)
    {
        // Append the portion of the original we skipped
        sb.Append(original.Substring(pos, match.Index));
        pos = match.Index;
        // Make any operations you like on the match result, like your own custom Replace, or even run another Regex
        
        pos += match.Value.Length;
    }
    sb.Append(original.Substring(pos, original.Length - 1));
    
