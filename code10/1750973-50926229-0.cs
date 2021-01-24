     [Test]
     public void MessageBoxShow_should_be_callable_indirectly()
     {
        using (new IndirectionsContext())
       {
        // Arrange
        var mockMessageBox = new Mock<IndirectionFunc<string, DialogResult>>();
        mockMessageBox.Setup(_ => _(string.Empty)).Returns(DialogResult.OK);
        PMessageBox.ShowString().Body = mockMessageBox.Object;
        // Act
        MessageBox.Show("This is a message");
        // Assert
        mockMessageBox.Verify(_ => _("This is a message"));
      }
    }
