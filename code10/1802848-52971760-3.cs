            var selectedDaysOfWeek = new List<DayOfWeek>();
            var from = DateTime.Parse("10/24/2018");
            var to = DateTime.Parse("11/14/2018");
            var dayList = new List<DateTime>();
            if (checkBoxMonday.IsChecked) { selectedDaysOfWeek.Add(DayOfWeek.Monday); }
            if (checkBoxTuesday.IsChecked) { selectedDaysOfWeek.Add(DayOfWeek.Tuesday); }
            if (checkBoxWednesday.IsChecked) { selectedDaysOfWeek.Add(DayOfWeek.Wednesday); }
            if (checkBoxThursday.IsChecked) { selectedDaysOfWeek.Add(DayOfWeek.Thursday); }
            if (checkBoxFriday.IsChecked) { selectedDaysOfWeek.Add(DayOfWeek.Friday); }
            if (checkBoxSaturday.IsChecked) { selectedDaysOfWeek.Add(DayOfWeek.Saturday); }
            if (checkBoxSunday.IsChecked) { selectedDaysOfWeek.Add(DayOfWeek.Sunday); }
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
            {
                if (selectedDaysOfWeek.Contains(day.DayOfWeek))
                {
                    dayList.Add(day);
                }
            }
            foreach(var day in dayList)
            {
                // Add to day to DB
            }
