    string inputString = "2323dfdf233fgfgfg ddfdf334";
    var list = new List<string>();
    int usedLength = 0;
    while (usedLength < inputString.Length)
    {
        bool isDigit = char.IsDigit(inputString[usedLength]);
        string item = string.Concat(inputString.Skip(usedLength).
                                                TakeWhile((c) => char.IsDigit(c) == isDigit));
        usedLength += item.Length;
        list.Add(item);
    };
