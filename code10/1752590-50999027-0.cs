    List<DataMold<T>> molds = new List<DataMold<T>>();
    molds.Add(new TextMold());
    molds.Add(new NumberMold());
    
    foreach (dynamic mold in molds)
        Console.WriteLine(mold.Result);
