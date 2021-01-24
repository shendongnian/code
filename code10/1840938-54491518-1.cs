    var myDic = new Dictionary<List<string>, Actions>();
    myDic.Add(new List<string>() { "Huey", "Dewey" }, Actions.Sleeping);
    myDic.Add(new List<string>() { "Dewey", "Louie" }, Actions.Playing);
    var newList = new List<string>() { "Dewey", "Louie" };
    if (myDic.Keys.Any(key =>
    {
        if (key.Count != newList.Count) return false;
        
        var same = true;
        for (int i = 0; i < newList.Count; i++)
        {
            if (key[i] != newList[i]) same = false;
        }
        return same;
    }))
        MsgBox("myDict contains the list of String, as Key Value");
    else
        MsgBox("myDict don't contains the list of String, as Key Value")
