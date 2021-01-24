    var molds = new List<object>();     // System.Object is the most derived common base type.
    molds.Add(new TextMold());
    molds.Add(new NumberMold());
    
    foreach (dynamic mold in molds)
        Console.WriteLine(mold.Result);
