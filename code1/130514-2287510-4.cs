    [Test]
    public void ReturnsDelimitedString()
    {
      string input = "F4194E7CC775F003";
      string actual = ToDelimitedString(input, 4, "-");
      Assert.AreEqual("F419-4E7C-C775-F003", actual);
    }
