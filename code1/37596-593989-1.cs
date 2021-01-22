    [Test]
    public void NamePropTest()
    {
        Person p = new Person();
        p.Name = "Sean";
        p.Surname = "Penn";
        Assert.AreEqual("Sean Penn", p.FullName);
    }
