    [Test]
    public void GetBoo_WhenCalled_ReturnBoo()
    {
        var foo = new Foo();
        var result = foo.GetBoo();
    
        Assert.that(result, Is.TypeOf<Boo>()); // False ("Boo") 
        Assert.that(result, Is.InstanceOf<Boo>()); //True ("Boo" or "Woo")
    }
