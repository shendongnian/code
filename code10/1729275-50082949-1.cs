    #if comp_x64
    [TestMethod]
    public void Testx64_Success()
    {
        if (Environment.Is64BitProcess)
        {
            //Arrange
            ...
            //Act
            ...
            //Assert
            Assert.IsTrue(true);
        }
        else
        {
            Assert.Inconclusive("Can't test x86 while running in x64 process.");
        }
    }
    #else
       . . . . your x86 test 
    #endif
