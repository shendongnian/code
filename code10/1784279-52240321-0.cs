            //Needed casting so I could remove the decimals.
            TimeSpan span = DateTime.Now.Subtract(dateBirthDate);
            //Creating workable if/else to account for birthday's yet to come.
            int dateCorrectorMonthNow = DateTime.Now.Month;
            int dateCorrectorDayNow = DateTime.Now.Day;
            int dateCorrectorMonthThen = dateBirthDate.Month;
            int dateCorrectorDayThen = dateBirthDate.Day;
            int years = (int)span.Days/365;
            int months = years * 12;
            int days = (int)span.TotalDays;
            int hours = (int)span.TotalHours;
            int minutes = (int)span.TotalMinutes;
            int seconds = (int)span.TotalSeconds;
            if (dateCorrectorMonthNow <= dateCorrectorMonthThen)
            {
                if (dateCorrectorDayNow  <= dateCorrectorDayThen)
                {
                    Console.WriteLine($"Years   :{years}");
                }
                else
                {
                    Console.WriteLine($"Years   :{years-1}");
                }
            }
            else
            {
                Console.WriteLine($"Years   :{years}");
            }
