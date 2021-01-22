        /// <summary>
        /// Gets the dates that mark the beginning of each week from the specified start date until today.
        /// </summary>
        /// <param name="weekStart">The day of the week that marks the beginning of a week</param>
        /// <param name="startDate">A date that determines the earliest week in the result.</param>
        /// <returns></returns>
        public IEnumerable<DateTime> GetWeeks(DayOfWeek weekStart, DateTime startDate)
        {
            DateTime current = DateTime.Today.AddDays(weekStart - DateTime.Today.DayOfWeek);
            while(current >= startDate)
            {
                yield return current;
                // move to the previous week
                current = current.AddDays(-7);
            }
        }
        public void PopulateUI()
        {
            // in this example, Monday is considered the start of the week,
            // and the drop down list will be populated with the date of each monday starting with this week going back to 1 year ago.
            ddlWeeks.DataSource = GetWeeks(DayOfWeek.Monday, DateTime.Today.AddYears(-1));
        }
