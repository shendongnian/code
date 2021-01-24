    private static Regex _regex = new Regex("({(.+?)})");
    ...
    public string Format(string rawMsg, IReadOnlyDictionary<string, object> dict) =>
        _regex.Replace(rawMsg, match =>
        {
            string placeHolder = match.ToString();
            
            return dict.TryGetValue(placeHolder, out object placeHolderValue) 
                        ? placeHolderValue.ToString() : null;
        });
