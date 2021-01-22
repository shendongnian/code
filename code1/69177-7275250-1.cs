            birthDateDisplay.Text = birthDate.ToString("MM/dd/yyyy");
            DateTime currentDate = DateTime.Now;
            Int32 numOfDays = 0; 
            Int32 numOfWeeks = 0;
            Int32 numOfMonths = 0; 
            Int32 numOfYears = 0; 
            // changed code to follow this model http://stackoverflow.com/posts/1083990/revisions
            //years 
            TimeSpan diff = currentDate - birthDate;
            numOfYears = diff.Days / 366;
            DateTime workingDate = birthDate.AddYears(numOfYears);
            while (workingDate.AddYears(1) <= currentDate)
            {
                workingDate = workingDate.AddYears(1);
                numOfYears++;
            }
            //months
            diff = currentDate - workingDate;
            numOfMonths = diff.Days / 31;
            workingDate = workingDate.AddMonths(numOfMonths);
            while (workingDate.AddMonths(1) <= currentDate)
            {
                workingDate = workingDate.AddMonths(1);
                numOfMonths++;
            }
            
            //weeks and days
            diff = currentDate - workingDate;
            numOfWeeks = diff.Days / 7; //weeks always have 7 days
            // if bday month is same as current month and bday day is after current day, the date is off by 1 day
            if(DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day)
                numOfDays = diff.Days % 7 + 1;
            else
                numOfDays = diff.Days % 7;
            // If the there are fewer than 31 days in the birth month, the date calculated is 1 off
            // Dont need to add a day for the first day of the month
            int daysInMonth = 0;
            if ((daysInMonth = DateTime.DaysInMonth(birthDate.Year, birthDate.Month)) != 31 && birthDate.Day != 1)
            {
                startDateforCalc = DateTime.Now.Date.AddDays(31 - daysInMonth);
                // Need to add 1 more day if it is a leap year and Feb 29th is the date
                if (DateTime.IsLeapYear(birthDate.Year) && birthDate.Day == 29)
                    startDateforCalc = startDateforCalc.AddDays(1);
            }
            yearsSpinEdit.Value = numOfYears;
            monthsSpinEdit.Value = numOfMonths;
            weeksSpinEdit.Value = numOfWeeks;
            daysSpinEdit.Value = numOfDays;
