    string input = "(a b | c.())";
    var tokens = tokenizer.Tokenize(input);
    var result = MyParsers.Expression.TryParse(tokens);
    if (result.HasValue)
    {
        // input is valid
        var expression = (Expression)result.Value;
        // do what you need with it here, i.e. loop through the nodes, output the text, etc.
    }
    else
    {
        // not valid
    }
