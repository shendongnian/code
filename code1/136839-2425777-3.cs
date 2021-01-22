    [Test]
    public void TestOfDateTime()
    {
         Isolate.WhenCalled(() => DateTime.Now).WillReturn(new DateTime(2000, 1, 1));
    
         var result = new UnderTest().CalculateSomethingBasedOnDate();
    }
