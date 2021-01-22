    [TestFixture]
    public class DateTimeExtensionTests
    {
      [Test]
      [Row(1, 2011, "2011-01-28")]
      [Row(2, 2011, "2011-02-25")]
      ...
      [Row(11, 2011, "2011-11-25")]
      [Row(12, 2011, "2011-12-30")]
      [Row(1, 2012, "2012-01-27")]
      [Row(2, 2012, "2012-02-24")]
      ...
      [Row(11, 2012, "2012-11-30")]
      [Row(12, 2012, "2012-12-28")]
      
      public void Test_GetLastFridayInMonth(int month, int year, string expectedDate)
      {
        var date = new DateTime(year, month, 1);
        var expectedValue = DateTime.Parse(expectedDate);
    
        while (date.Month == month)
        {
          var result = date.GetLastFridayInMonth();
          Assert.AreEqual(expectedValue, result);
          date = date.AddDays(1);
        }
      }
    }
