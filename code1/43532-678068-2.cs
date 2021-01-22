    //earlier
    var KeySplitter = new Regex ("(=)|({)|(})|(\\|)", RegexOptions.Compiled);
.
    //later
    string test = ""; // 
    for (string key in KeySplitter.Split(test).Where(s => !string.IsNullOrEmpty(s)))
    {
        // ...
    }
