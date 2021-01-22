    [Test]
    public void DisposeSample()
    {
        using (var disposableClass = new DisposableClass())
        {
            Assert.IsFalse(DisposableClass.WasDisposed);
        }
    
        Assert.IsTrue(DisposableClass.WasDisposed);
    }
