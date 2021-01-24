    [TestMethod]
    public void TestLoginMethodValid()
    {
      MockLoginService mockLoginService = new MockLoginService();
      Timetable auth = new Timetable(mockLoginService);
      bool result = auth.TimetableLogin("Name", "Password"); 
      Assert.IsTrue(result);
    }
