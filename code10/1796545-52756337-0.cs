    [Test]
    public void MultpleRecordsFileAsync()
    {
        engine = new MultiRecordEngine(new RecordTypeSelector(CustomSelector),
            typeof (OrdersVerticalBar),
            typeof (CustomersSemiColon),
            typeof (SampleType));
    
        var res = new ArrayList();
        engine.BeginReadFile(FileTest.Good.MultiRecord1.Path);
        foreach (var o in engine)
            res.Add(o);
    
        Assert.AreEqual(12, res.Count);
        Assert.AreEqual(12, engine.TotalRecords);
    
        Assert.AreEqual(typeof (OrdersVerticalBar), res[0].GetType());
        Assert.AreEqual(typeof (OrdersVerticalBar), res[1].GetType());
        Assert.AreEqual(typeof (CustomersSemiColon), res[2].GetType());
        Assert.AreEqual(typeof (SampleType), res[5].GetType());
    }
        
    [Test]
    public void MultpleRecordsWriteAsync()
    {
        engine = new MultiRecordEngine(new RecordTypeSelector(CustomSelector),
            typeof (OrdersVerticalBar),
            typeof (CustomersSemiColon),
            typeof (SampleType));
    
        object[] records = engine.ReadFile(FileTest.Good.MultiRecord1.Path);
    
        engine.BeginWriteFile("tempoMulti.txt");
        foreach (var o in records)
            engine.WriteNext(o);
        engine.Close();
        File.Delete("tempoMulti.txt");
    
    
        object[] res = engine.ReadFile(FileTest.Good.MultiRecord1.Path);
    
        Assert.AreEqual(12, res.Length);
        Assert.AreEqual(12, engine.TotalRecords);
    
        Assert.AreEqual(typeof (OrdersVerticalBar), res[0].GetType());
        Assert.AreEqual(typeof (OrdersVerticalBar), res[1].GetType());
        Assert.AreEqual(typeof (CustomersSemiColon), res[2].GetType());
        Assert.AreEqual(typeof (SampleType), res[5].GetType());
    }
