    var dict = new Dictionary<string, string>();
    // load dictionary here
    var original = "ABC";
    var newOne = new StringBuilder();
    foreach (var c in original)
        newOne.Append(dict[c]);
    return newOne.ToString();
