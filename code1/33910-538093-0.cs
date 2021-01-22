    public void WasteMemory()
    {
        var instance = new MyCollection(); // this one has no Dispose() method
        instance.FillItWithAMillionStrings();
    }
    // 1 million strings are in memory, but marked for reclamation by the GC
