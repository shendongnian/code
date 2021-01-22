    [TestFixture]
    public abstract class DateDifferenceTests<DDC> where DDC : IDateDifference, new()
    {
      protected IDateDifference ddClass;
      [SetUp]
      public void Init()
      {
        ddClass = new DDC();
      }
      [Test]
      public void BasicTest()
      {
        ddClass.SetDates(new DateTime(2012, 12, 1), new DateTime(2012, 12, 25));
        CheckResults(0, 0, 24);
      }
      [Test]
      public void AlmostTwoYearsTest()
      {
        ddClass.SetDates(new DateTime(2010, 8, 29), new DateTime(2012, 8, 14));
        CheckResults(1, 11, 16);
      }
      [Test]
      public void AlmostThreeYearsTest()
      {
        ddClass.SetDates(new DateTime(2009, 7, 29), new DateTime(2012, 7, 14));
        CheckResults(2, 11, 15);
      }
      [Test]
      public void BornOnALeapYearTest()
      {
        ddClass.SetDates(new DateTime(2008, 2, 29), new DateTime(2009, 2, 28));
        CheckControversialResults(0, 11, 30, 1, 0, 0);
      }
      [Test]
      public void BornOnALeapYearTest2()
      {
        ddClass.SetDates(new DateTime(2008, 2, 29), new DateTime(2009, 3, 1));
        CheckControversialResults(1, 0, 0, 1, 0, 1);
      }
      [Test]
      public void LongMonthToLongMonth()
      {
        ddClass.SetDates(new DateTime(2010, 1, 31), new DateTime(2010, 3, 31));
        CheckResults(0, 2, 0);
      }
      [Test]
      public void LongMonthToLongMonthPenultimateDay()
      {
        ddClass.SetDates(new DateTime(2009, 1, 31), new DateTime(2009, 3, 30));
        CheckResults(0, 1, 30);
      }
      [Test]
      public void LongMonthToShortMonth()
      {
        ddClass.SetDates(new DateTime(2009, 8, 31), new DateTime(2009, 9, 30));
        CheckControversialResults(0, 1, 0, 0, 0, 30);
      }
      [Test]
      public void LongMonthToPartWayThruShortMonth()
      {
        ddClass.SetDates(new DateTime(2009, 8, 31), new DateTime(2009, 9, 10));
        CheckResults(0, 0, 10);
      }
      private void CheckResults(int years, int months, int days)
      {
        Assert.AreEqual(years, ddClass.GetYears());
        Assert.AreEqual(months, ddClass.GetMonths());
        Assert.AreEqual(days, ddClass.GetDays());
      }
      private void CheckControversialResults(int years, int months, int days,
        int yearsAlt, int monthsAlt, int daysAlt)
      {
        // gives the right output but unhelpful messages
        bool success = ((ddClass.GetYears() == years
                         && ddClass.GetMonths() == months
                         && ddClass.GetDays() == days)
                        ||
                        (ddClass.GetYears() == yearsAlt
                         && ddClass.GetMonths() == monthsAlt
                         && ddClass.GetDays() == daysAlt));
        Assert.IsTrue(success);
      }
    }
