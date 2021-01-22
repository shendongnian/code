    //earlier
    RegEx KeySplitter = new RegEx ("(=)|({)|(})|(\\|)");
.
    //later
    string test = ""; // 
    for (string key in KeySplitter.Split(test).Where(s => !string.IsNullOrEmpty(s)))
    {
        // ...
    }
