    /**
        /// <summary>An extension method that returns the last day of the month.</summary>
        /// <param name="d">A date within the month to calculate.</param>
        /// <returns>The last day of the current month.</returns>
        **/
        public static DateTime LastDayOfMonth(this DateTime d)
        {
            DateTime nextMonth = new DateTime(d.Year, d.Month, 1).AddMonths(1);
            return nextMonth.AddDays(-1);
        }
        /**
        /// <summary>An extension method that returns the last <see cref="DayOfWeek"> of the month.</summary>
        /// <param name="d">A date within the month to calculate.</param>
        /// <returns>The last day of the current month.</returns>
        **/
        public static DateTime LastDayOfMonth(this DateTime d, DayOfWeek dayOfWeek)
        {
            DateTime lastDayOfMonth = d.LastDayOfMonth();
            int vector = (((int)lastDayOfMonth.DayOfWeek - (int)dayOfWeek + DaysInWeek) % DaysInWeek);
            return lastDayOfMonth.AddDays(-vector);
        }
     #region LastDayOfMonth Tests
        [TestCase("1/1/2011", "1/31/2011")]
        [TestCase("2/1/2009", "2/28/2009")] //Leap Year
        [TestCase("2/1/2008", "2/29/2008")] //Leap Year
        [TestCase("3/10/2011", "3/31/2011")]
        [TestCase("4/20/2011", "4/30/2011")]
        [TestCase("5/15/2011", "5/31/2011")]
        [TestCase("6/30/2011", "6/30/2011")]
        [TestCase("12/1/2011", "12/31/2011")]
        public void LastDayOfMonthReturnsCorrectDay(string startingDate, string expectedDate)
        {
            //Arrange
            DateTime testDate = DateTime.Parse(startingDate);
            DateTime expected = DateTime.Parse(expectedDate);
            //Act
            DateTime actual = testDate.LastDayOfMonth();
            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [TestCase("1/1/2011", DayOfWeek.Monday, "1/31/2011")]
        [TestCase("2/1/2009", DayOfWeek.Saturday, "2/28/2009")]
        [TestCase("2/1/2009", DayOfWeek.Sunday, "2/22/2009")] 
        [TestCase("2/1/2008", DayOfWeek.Friday, "2/29/2008")] //Leap Year
        [TestCase("2/1/2008", DayOfWeek.Thursday, "2/28/2008")] //Leap Year
        [TestCase("3/10/2011", DayOfWeek.Wednesday, "3/30/2011")]
        [TestCase("4/20/2011", DayOfWeek.Friday, "4/29/2011")]
        [TestCase("4/20/2011", DayOfWeek.Saturday, "4/30/2011")]
        [TestCase("5/15/2011", DayOfWeek.Tuesday, "5/31/2011")]
        [TestCase("5/15/2011", DayOfWeek.Saturday, "5/28/2011")]
        [TestCase("9/30/2011", DayOfWeek.Sunday, "9/25/2011")]
        [TestCase("12/1/2011", DayOfWeek.Monday, "12/26/2011")]
        public void LastDayOfMonthReturnsCorrectDayOfWeek(string startingDate, DayOfWeek dayOfWeek, string expectedDate)
        {
            //Arrange
            DateTime testDate = DateTime.Parse(startingDate);
            DateTime expected = DateTime.Parse(expectedDate);
            //Act
            DateTime actual = testDate.LastDayOfMonth(dayOfWeek);
            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }		
        #endregion
