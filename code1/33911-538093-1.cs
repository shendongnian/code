    public void WasteMemory()
    {
        var instance = new MyCollection(); // this one has your Dispose()
        instance.FillItWithAMillionStrings();
        instance.Dispose();
    }
    // 1 million strings are in memory, but marked for reclamation by the GC
