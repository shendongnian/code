    var tokensInString = FindTokens(input);
    var tokenContent = GetControls( tokensInString );
    foreach( var pair in tokenContent ) 
    {
        input = input.Replace( "[$" + pair.Key + "$]", pair.Value);
    }
