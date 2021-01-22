    [Test]
    TestMethod()
    {
    
        Person p = new Person();
        p.Name = "a name";
        p.Surname = "a surname";
    
        Assert.That(p.Name, Is.EqualTo("a name"));
        Assert.That(p.Surname, Is.EqualTo("a surname"));
    }
