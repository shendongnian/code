    var input = "asdfasfas";
    if (!Regex.IsMatch(input, "[0-9]"))
    {
        // will occure
    }
    else
    {
        // will not occure
    }
    var input2 = "asdf123Aasdfasdf";
    if (!Regex.IsMatch(input2, "[0-9]"))
    {
        // will not occure
    }
    else
    {
        // will occure
    }
