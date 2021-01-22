    public string GetReplacement(Match m) {
        return m.Groups[1].Success ? m.Groups[1].Value : "YYY";
    }
    Regex r = new Regex( @"(?is)(<([abi]\b)[^<>]*>.*?</\2>)|XXX" );
    string newString = r.Replace(oldString,
                       new MatchEvaluator(GetReplacement));
