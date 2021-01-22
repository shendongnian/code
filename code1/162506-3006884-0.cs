    [Test]
    public void Write_MessageLogWithCategoryInfoFail()
    {
        try
        {
          string message = "Info Test Message";
          Write_MessageLogWithCategory(message, "Info");
          _LogTest.Verify(writeMessage =>
              writeMessage.Info("This should fail"),
              "Actual differs from expected"
          );
          Assert.Fail("Expected exception");
        }
        catch(MockException e)
        {
          Assert.AreEqual("Actual differs from expected", e.Message);
        }
    }
