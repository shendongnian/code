    [TestMethod]
    public void MethodTest()
    {
        try
        {
            var obj = new ClassRequiringNonNullParameter( null );
            Assert.Fail("An exception should have been thrown");
        }
        catch (ArgumentNullException ae)
        {
            Assert.AreEqual( "Parameter cannot be null or empty.", ae.Message );
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format( "Unexpected exception of type {0} caught",
                                e.GetType() )
            );
        }
    }
