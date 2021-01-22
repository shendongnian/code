    [TestMethod()]
    public void ExceptionTest()
    {
        String testStr = null;
        MyAssert.Throws<NullReferenceException>(() => testStr.ToUpper());
    }
