    [TestMethod]
    public void WasClipboardRead()
    {
      // Arrange
      var mock = new MockClipboard();
      var obj = new Object();
      
      // Act
      DoCtrlV(obj, mock);
      // Assert
      Assert.IsTrue(mock.ClipboardWasRead);
    }
