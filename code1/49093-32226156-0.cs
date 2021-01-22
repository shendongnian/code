    var list = new List<YourData>();
    ... populate the list ...
    //foreach (var entryToProcess in list)
    for (int i = 0; i < list.Count; i++)
    {
        var entryToProcess = list[i];
        var resultOfProcessing = DoStuffToEntry(entryToProcess);
        if (... condition ...)
            list.Add(new YourData(...));
    }
