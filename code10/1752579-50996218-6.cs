    List<IDataMold> molds = new List<IDataMold>();
    molds.Add(new TextMold());
    molds.Add(new NumberMold());
    foreach (var mold in molds)
    {
        Console.WriteLine(mold.ToString());
    }
