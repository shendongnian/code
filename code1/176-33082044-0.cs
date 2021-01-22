            DateTime CalculateAge(DateTime DateOfBirth)
        {
            //Get DateTime of Now.
            var now = DateTime.Now;
            //Get Month of Birth.
            var currentMonth = DateOfBirth.Month;
            //Actual Age.
            int years = 0, months = 0,
                //Get Days count from birthday to now.
                days = (now - DateOfBirth).Days;
            //It means that the days is more than month.
            while (days >= MonthDays(currentMonth))
            {
                months++; //Add one Month
                //Remove the current Month days from life Days.
                days -= MonthDays(currentMonth);
                if (months == 12)
                {   //If it's December then:
                    years++; //Add new Year.
                    months = 0; //Clear Months.
                }
                //If current month reached 12 set it to 0
                if (currentMonth == 12)
                    currentMonth = 0;
                //Move to next Month.
                currentMonth++;
            }
            //Every 4 years the current February days= 29 not 28
            var daysToRemove = Convert.ToInt32(years / 4);
            //Remove these days as today to calculate days correct.
            var editedDate = new DateTime(now.Year, now.Month, days)
                .AddDays(-daysToRemove);
            //Just take days only, calculate years and months.
            return new DateTime((editedDate.Year - now.Year) + years,
               (editedDate.Month - now.Month) + months, editedDate.Day);
        }
        int MonthDays(int Month)
        {
            switch (Month)
            {   //Month: Days.
                case 1: return 31;
                case 2: return 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default: return 0;
            }
        }
