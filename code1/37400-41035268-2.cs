    [TestMethod]
    public void TestMethod1()
    {
        List<Type> extraTypes = new List<Type>();
        extraTypes.Add(typeof(IdleMessage));
        AbstractXmlSerializer<XmlMessage> ser = new AbstractXmlSerializer<XmlMessage>(extraTypes);
        String xmlMsg = "<idle></idle>";
                       
        MutcMessage result = ser.Deserialize(xmlMsg);
        Assert.IsTrue(result is IdleMessage);           
    }
