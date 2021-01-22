    /// <summary>
            /// Returns a date for the next occurance of a given month
            /// </summary>
            /// <param name="date">The starting date</param>
            /// <param name="month">The month requested. Valid values (1-12)</param>
            /// <param name="day">The day requestd. Valid values (1-31)</param>
            /// <returns>The next occurance of the date.</returns>
            public DateTime GetNextMonthByIndex(DateTime date, int month, int day)
            {
                // we are in the target month and the day is less than the target date
                if (date.Month == month && date.Day <= day)
                    return new DateTime(date.Year, month, day);
    
                //add month to date until we hit our month
                while (true)
                {
                    date = date.AddMonths(1);
                    if (date.Month == month)
                        return new DateTime(date.Year, month, day);
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                DateTime d = DateTime.Now;            
                
                //get the next august
                Text = GetNextMonthByIndex(d, 8, 31).ToString();
            }
