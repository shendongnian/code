    // Note the matching groups around each string
    var regex = new Regex("(string1)|(string2)|(string3)");
    foreach(var item in myList) {
        var match = regex.Match(item);
        if (!match.Success) {
            continue;
        }
        if (match.Groups[1].Success) {
            myFunction1(item);
        }
        else if (match.Groups[2].Success)
        {
            myFunction2(item);
        }
        else if (match.Groups[3].Success)
        {
            myFunction3(item);
        }
    }
