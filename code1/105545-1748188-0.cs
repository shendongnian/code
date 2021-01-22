    // first loop
    var captures = new Captures();
    foreach (var v in values)
    {
        captures.Value = v;
        funcs.Add(captures.Function);
    }
    // second loop
    foreach (var v in values)
    {
        var captures = new Captures();
        captures.Value = v;
        funcs.Add(captures.Function);
    }
    // ...
    private class Captures
    {
        public int Value;
        public int Function()
        {
            return Value;
        }
    }
