        [Test]
        [TestCase(0, 50)]
        public void GetYears_GetCalendarListYearWithEmptyYear_ReturnCalendarListYearsStartingCurrentYear(int startingYear, int rangeYears)
        {
            var sut = new InstanceOfYourCalculator();
            GenericListItems<CalendarYearItem> calendar = sut.GetYears(startingYear, rangeYears);
            Assert.That(calendar, Has.Count.EqualTo(rangeYears));
            var expectedResult = Enumerable.Range(DateTime.Now.Year, rangeYears).Select(x => new CalendarYearItem(x++)).ToList();
            CollectionAssert.AreEqual(expectedResult, calendar);
        }
