    public void MatchSomethings(string input)
    {
        var data = new List<something>();
        var wordsInName = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var match = data.Where(s => wordsInName.All(word => s.Name.Contains(word)));
    }
