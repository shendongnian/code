    [TestMethod]
    public void Test_ThatMyEventIsRaised()
    {
        Dictionary<string, int> receivedEvents = new Dictionary<string, int>();
        MyClass myClass = new MyClass();
    
        myClass.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
        {
            if (receivedEvents.ContainsKey(e.PropertyName))
                receivedEvents[e.PropertyName]++;
            else
                receivedEvents.Add(e.PropertyName, 1);
        };
    
        myClass.MyProperty = "testing";
        Assert.IsTrue(receivedEvents.ContainsKey("MyProperty"));
        Assert.AreEqual(1, receivedEvents["MyProperty"]);
        Assert.IsTrue(receivedEvents.ContainsKey("MyOtherProperty"));
        Assert.AreEqual(1, receivedEvents["MyOtherProperty"]);
    }
