    [Test]
    [TestCaseSource(typeof(StackTestCases))]
    public void PushToStack(IStack stack)
    {
        //Arrange/Act
        stack.Push(1);
        //Assert
        Assert.AreEqual(1, stack.Peek());
    }
