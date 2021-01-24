    var nameIndicator = "my name is ";
    var index = inputValue.ToLower().IndexOf(nameIndicator);
    if (index == -1)
    {
        // Not found
    }
    else
    {
        var name = inputValue.Substring(index + nameIndicator.Length);
    }
