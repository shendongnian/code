    string lyrics = ...
    var verseGroups = lyrics
        .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
        .Select(s => s.Trim())  // Optional, if there might be whitespace
        .Split(s => string.IsNullOrEmpty(s))
        .Zip(seq => string.Join(Environment.NewLine, seq.ToArray()))
        .Select(s => s + Environment.NewLine);  // Optional, add space between groups
