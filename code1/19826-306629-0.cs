    private string MyMethod(Match match, bool param1, int param2)
    {
        //Do stuff here
    }
    
    Regex reg = new Regex(@"{regex goes here}", RegexOptions.IgnoreCase);
    Content = reg.Replace(Content, new MatchEvaluator(delegate(Match match) { return MyMethod(match, false, 0); }));
