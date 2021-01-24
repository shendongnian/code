    List<String> ModelNumberPrefixes = new List<String>();
    ModelNumberPrefixes.Add("A1C1C");
    ModelNumberPrefixes.Add("A1C1D");
    //etc
    ModelNumberPrefixes.ForEach(s => {
        if (ModelNumber.StartsWith(s)) {
           //Whatever you need to do in your big if block
        }
    });
