    var lines = text.Split(new []{Environment.NewLine}, StringSplitOptions.None); //split the string in lines
    var dictionary = new Dictionary<string, string>();
    foreach (var line in lines)
    {
        var lineParts = line.Split(':'); //split line to parts with : as delimiter
        var key = lineParts[0]; //first part is the key
        var value = lineParts[1]; //second part is the value
        dictionary.Add(key, value);
    }
