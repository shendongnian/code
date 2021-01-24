    var lines = text.Split( Environment.NewLine ); //split the string in lines
    var dictionary = new Dictionary<string, string>();
    foreach ( var line in lines )
    {
        var lineParts = line.Split(":");
        var key = line[0];
        var value = line[1];
        dictionary.Add( key, value );
    }
