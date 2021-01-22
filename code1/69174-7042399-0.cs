            public static class GeneralHelper
            {
              public static int GetYears(DateTime startDate, DateTime endDate)
                {
                    if (endDate < startDate)
                        return -GetYears(endDate, startDate);
        
                    int years = (endDate.Year - startDate.Year);
        
                    if (endDate.Year == startDate.Year)
                        return years;
        
                    if (endDate.Month < startDate.Month)
                        return years - 1;
        
                    if (endDate.Month == startDate.Month && endDate.Day < startDate.Day)
                        return years - 1;
        
                    return years;
                }
        
                public static int GetMonths(DateTime startDate, DateTime endDate)
                {
                    if (startDate > endDate)
                        return -GetMonths(endDate, startDate);
        
                    int months = 12 * GetYears(startDate, endDate);
        
                    if (endDate.Month > startDate.Month)
                        months = months + endDate.Month - startDate.Month;
                    else
                        months = 12 - startDate.Month + endDate.Month;
        
                    if (endDate.Day < startDate.Day)
                        months = months - 1;
        
                    return months;
                }
           }
        [TestClass()]
        public class GeneralHelperTest
        {
                [TestMethod]
                public void GetYearsTest()
                {
                    Assert.AreEqual(0, GeneralHelper.GetYears(new DateTime(2000, 5, 5), new DateTime(2000, 12, 31)));
                    Assert.AreEqual(0, GeneralHelper.GetYears(new DateTime(2000, 5, 5), new DateTime(2001, 4, 4)));
                    Assert.AreEqual(0, GeneralHelper.GetYears(new DateTime(2000, 5, 5), new DateTime(2001, 5, 4)));
                    Assert.AreEqual(1, GeneralHelper.GetYears(new DateTime(2000, 5, 5), new DateTime(2001, 5, 5)));
                    Assert.AreEqual(1, GeneralHelper.GetYears(new DateTime(2000, 5, 5), new DateTime(2001, 12, 31)));
        
                    Assert.AreEqual(0, GeneralHelper.GetYears(new DateTime(2000, 12, 31), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(0, GeneralHelper.GetYears(new DateTime(2001, 4, 4), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(0, GeneralHelper.GetYears(new DateTime(2001, 5, 4), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(-1, GeneralHelper.GetYears(new DateTime(2001, 5, 5), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(-1, GeneralHelper.GetYears(new DateTime(2001, 12, 31), new DateTime(2000, 5, 5)));
                }
        
                [TestMethod]
                public void GetMonthsTest()
                {
                    Assert.AreEqual(0, GeneralHelper.GetMonths(new DateTime(2000, 5, 5), new DateTime(2000, 6, 4)));
                    Assert.AreEqual(1, GeneralHelper.GetMonths(new DateTime(2000, 5, 5), new DateTime(2000, 6, 5)));
                    Assert.AreEqual(1, GeneralHelper.GetMonths(new DateTime(2000, 5, 5), new DateTime(2000, 6, 6)));
                    Assert.AreEqual(11, GeneralHelper.GetMonths(new DateTime(2000, 5, 5), new DateTime(2001, 5, 4)));
                    Assert.AreEqual(12, GeneralHelper.GetMonths(new DateTime(2000, 5, 5), new DateTime(2001, 5, 5)));
                    Assert.AreEqual(13, GeneralHelper.GetMonths(new DateTime(2000, 5, 5), new DateTime(2001, 6, 6)));
        
                    Assert.AreEqual(0, GeneralHelper.GetMonths(new DateTime(2000, 6, 4), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(-1, GeneralHelper.GetMonths(new DateTime(2000, 6, 5), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(-1, GeneralHelper.GetMonths(new DateTime(2000, 6, 6), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(-11, GeneralHelper.GetMonths(new DateTime(2001, 5, 4), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(-12, GeneralHelper.GetMonths(new DateTime(2001, 5, 5), new DateTime(2000, 5, 5)));
                    Assert.AreEqual(-13, GeneralHelper.GetMonths(new DateTime(2001, 6, 6), new DateTime(2000, 5, 5)));
                }
       }
