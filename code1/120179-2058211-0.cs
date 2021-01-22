    public void Run()
    {
        Blah b = Dao.GetBlah(23);
        SomeService.ModifyXml(b);    // do I need to use out or ref here?
        Dao.SaveXml(b.Xml);
        SomeService.SubstituteNew(out b);
        Dao.SaveXml(b.Xml);
        
        SomeService.ReadThenReplace(ref b);
        Dao.SaveXml(b.Xml);
    }
