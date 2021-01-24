    var subStrings = new[] {"abc", "123"};
    string result = null;
    int position = stringVar.Length;
    foreach(var sub in subStrings)
    {
        var currPos = stringVar.IndexOf(sub);
        if(currPos > -1 && currPos < position)
        {
            position = currPos;
            result = sub;
        }
    }
    return result;
