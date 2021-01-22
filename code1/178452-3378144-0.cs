    [Test]
    public void SetReferenceArgument()
    {
        var myClass = new MyClass();
        object arg = null;
        myClass.M(ref arg);
        
        Assert.That(arg, Is.Not.Null);
    }
