    [Test]
    public void DoesNotThrowSpecificException()
    {
        try
        {
            MethodThatShouldntThrowExactException(); // But may throw any other exception
        }
        catch (Exception ex)
        {
            Assert.That(ex, Is.Not.TypeOf(typeof(ExactException)));
        }
    }
