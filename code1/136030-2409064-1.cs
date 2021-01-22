    public void TestMethod1()
    {
        string asciibase = "Dutch has funny chars: a,e,u";
        string diacrits = "                       ' \" \"";
        var merged = DiacritMerger.Merge(asciibase, diacrits);
    }
