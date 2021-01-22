        [Test]
        public void Calculate_Total_Months_Difference_Between_Two_Dates()
        {
            var startDate = DateTime.Parse( "10/8/1996" );
            var finishDate = DateTime.Parse( "9/8/2012" );  // this should be now:
            int numberOfMonthsBetweenStartAndFinishYears = getNumberOfMonthsBetweenStartAndFinishYears( startDate, finishDate );
            int absMonthsApartMinusOne = getAbsMonthsApartMinusOne( startDate, finishDate, numberOfMonthsBetweenStartAndFinishYears );
            decimal daysLeftToCompleteStartMonthPercentage = getDaysLeftToCompleteInStartMonthPercentage( startDate );
            decimal daysCompletedSoFarInFinishMonthPercentage = getDaysCompletedSoFarInFinishMonthPercentage( finishDate );
            // .77 + .26 = 1.04
            decimal totalDaysDifferenceInStartAndFinishMonthsPercentage = daysLeftToCompleteStartMonthPercentage + daysCompletedSoFarInFinishMonthPercentage;
            // 13 + 1.04 = 14.04 months difference.
            decimal totalMonthsDifference = absMonthsApartMinusOne + totalDaysDifferenceInStartAndFinishMonthsPercentage;
            //return totalMonths;
        }
        private static int getNumberOfMonthsBetweenStartAndFinishYears( DateTime startDate, DateTime finishDate )
        {
            int yearsApart = startDate.Year - finishDate.Year;
            const int INT_TotalMonthsInAYear = 12;
            // 12 * 1 = 12
            int numberOfMonthsBetweenYears = INT_TotalMonthsInAYear * yearsApart;
            
            return numberOfMonthsBetweenYears;
        }
        private static int getAbsMonthsApartMinusOne( DateTime startDate, DateTime finishDate, int numberOfMonthsBetweenStartAndFinishYears )
        {
            // This may be negative i.e. 7 - 9 = -2
            int numberOfMonthsBetweenStartAndFinishMonths = startDate.Month - finishDate.Month;
            // Absolute Value Of Total Months In Years Plus The Simple Months Difference Which May Be Negative So We Use Abs Function
            int absDiffInMonths = Math.Abs( numberOfMonthsBetweenStartAndFinishYears + numberOfMonthsBetweenStartAndFinishMonths );
            // Subtract one here because we are going to use a perecentage difference based on the number of days left in the start month
            // and adding together the number of days that we've made it so far in the finish month.
            int absMonthsApartMinusOne = absDiffInMonths - 1;
            return absMonthsApartMinusOne;
        }
        /// <summary>
        /// For example for 7/8/2012 there are 24 days left in the month so about .77 percentage of month is left.
        /// </summary>
        private static decimal getDaysLeftToCompleteInStartMonthPercentage( DateTime startDate )
        {
            // startDate = "7/8/2012"
            // 31
            decimal daysInStartMonth = DateTime.DaysInMonth( startDate.Year, startDate.Month );
            // 31 - 8 = 23 
            decimal totalDaysInStartMonthMinusStartDay = daysInStartMonth - startDate.Day;
            // add one to mark the day as being completed. 23 + 1 = 24
            decimal daysLeftInStartMonth = totalDaysInStartMonthMinusStartDay + 1;
            // 24 / 31 = .77 days left to go in the month
            decimal daysLeftToCompleteInStartMonthPercentage = daysLeftInStartMonth / daysInStartMonth;
            return daysLeftToCompleteInStartMonthPercentage;
        }
        /// <summary>
        /// For example if the finish date were 9/8/2012 we've completed 8 days so far or .24 percent of the month
        /// </summary>
        private static decimal getDaysCompletedSoFarInFinishMonthPercentage( DateTime finishDate )
        {
            // for septebmer = 30 days in month.
            decimal daysInFinishMonth = DateTime.DaysInMonth( finishDate.Year, finishDate.Month );
            // 8 days divided by 30 = .26 days completed so far in finish month.
            decimal daysCompletedSoFarInFinishMonthPercentage = finishDate.Day / daysInFinishMonth;
            return daysCompletedSoFarInFinishMonthPercentage;
        }
