    [TestMethod]
    [ExpectedException(typeof(Exception), AllowDerivedTypes = true)] // change the attribute settings
    public void Foo()
    {
        // do arrange:
        ExceptionAssert.AssertException<Exception>(() => // change "Exception" to the required exception type or left it as any exception
        {
            // do the act:
        }, exception =>
         {
             // do you asserts statements:
         });
    }
    [TestMethod]
    public void FooBar()
    {
        // do arrange:
        ExceptionAssert.AssertExceptionWithoutExcepctedExceptionAttribute<Exception>(() => // change "Exception" to the required exception type or left it as any exception
        {
            // do the act:
        }, exception =>
        {
            // do you asserts statements:
        }, false);
    }
