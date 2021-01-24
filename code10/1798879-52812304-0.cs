    //
            // Summary:
            //     Initializes a new instance of the System.DateTime structure to the specified
            //     year, month, and day.
            //
            // Parameters:
            //   year:
            //     The year (1 through 9999).
            //
            //   month:
            //     The month (1 through 12).
            //
            //   day:
            //     The day (1 through the number of days in month).
            //
            // Exceptions:
            //   T:System.ArgumentOutOfRangeException:
            //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
            //     than 12. -or- day is less than 1 or greater than the number of days in month.
            public DateTime(int year, int month, int day);
