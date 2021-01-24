    public class Form1Test
    {
      public void OnError_WithAny_CallsShow()
      {
        // Arrange
        var mbr = Substitute.For<IMessageBoxRepository>();
        var mbrFunc = Substitute.For<Func<IMessageBoxRepository>>();
        mbrFunc().Returns(mbr);
        var form1 = new Form1(mbrFunc);
        // Act
        form1.OnError(null);
        // Assert
        mbr.Received().Show();
      }
    }
