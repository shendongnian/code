    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void MethodTest()
    {
         var obj = new ClassRequiringNonNullParameter( null );
    }
