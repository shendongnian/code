        private int GetYearDiff(DateTime start, DateTime end)
        {
            int diff = end.Year - start.Year;
            if (end.DayOfYear < start.DayOfYear) { diff -= 1; }
            return diff;
        }
        [Fact]
        public void GetYearDiff_WhenCalls_ShouldReturnCorrectYearDiff()
        {
            //arrange
            var now = DateTime.Now;
            //act
            //assert
            Assert.Equal(24, GetYearDiff(new DateTime(1992, 7, 9), now)); // passed
            Assert.Equal(24, GetYearDiff(new DateTime(1992, now.Month, now.Day), now)); // passed
            Assert.Equal(23, GetYearDiff(new DateTime(1992, 12, 9), now)); // passed
        }
