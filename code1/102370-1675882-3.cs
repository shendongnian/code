    // testing silverlight behaviour of MyClass under full CLR
    [TestMethod]
    public void Test_SilverlightBehaviour ()
    {
        // setup mock, using Moq below
        Mock<IRuntimeInfo> _mockRuntimeInfo = new Mock<IRuntimeInfo> ();
        _mockRuntimeInfo.Setup (r => r.IsSilverlight).Returns (true);
        // pass mock to consumer
        MyClass myClass = new MyClass (_mockRuntimeInfo);
        // test silverlight-specific behaviour
        myClass.SomeMethod ();
    }
    // testing CLR behaviour of MyClass under full CLR
    [TestMethod]
    public void Test_FullClrBehaviour ()
    {
        // setup mock, using Moq below
        Mock<IRuntimeInfo> _mockRuntimeInfo = new Mock<IRuntimeInfo> ();
        _mockRuntimeInfo.Setup (r => r.IsSilverlight).Returns (false);
        // pass mock to consumer
        MyClass myClass = new MyClass (_mockRuntimeInfo);
        // test full-Clr-specific behaviour
        myClass.SomeMethod ();
    }
