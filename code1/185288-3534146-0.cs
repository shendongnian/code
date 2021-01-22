    [Test]
    public void NewElement()
    {
        String xmlString = @"<elem></elem>";
        string elementName;
        int elementDepth;
    
        this.xml.InputStream = new StringReader(xmlString);
        this.xml.NewElement += (name,depth) => { elementName = name; elementDepth = depth };
    
        this.xml.Start();
    
        Assert.AreEqual("elem", elementName);
        Assert.AreEqual(0, elementDepth);
    }
