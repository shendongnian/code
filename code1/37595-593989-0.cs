    [Test]
    public void NamePropTest()
    {
        Person p = new Person();
        //Some code here that will set up the Person object
        //  so that you know what the name will be
        Assert.AreEqual("some known value...", p.Name);
    }
