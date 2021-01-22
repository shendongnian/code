    [Test]
    [TestCase(null)]
    public void FooCalculation_InvalidInput_ShouldThrowArgumentNullExeption(string text)
    {
        var foo = new Foo();
        Assert.That(() => foo.Calculate(text), Throws.ArgumentNullExeption);
    }
