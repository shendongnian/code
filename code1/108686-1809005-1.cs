    [Test]
    public void Test()
    {
        string xml = "<root><b>nice </b><c>node</c><d><e> is here</e></d></root>";
        string result = StripXmlTags(xml);
    
        Assert.AreEqual("nice node is here", result);
    }
