    [Test]
    public void SomeTest()
    {
        var sc = new SomeClass();
            // Instantiate SomeClass as sc object
        sc.SomeMethod();
            // Call SomeMethod in the sc object.
        Assert.That(sc.SomeProp, Is.True );
            // Assert that the property is true... 
            // or change to Is.False if that's what you're after...
    }
