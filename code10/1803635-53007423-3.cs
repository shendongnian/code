     [HttpPost]
     public bool updateHoliday(List<Holidaysclass> data)
        {
            for (var i = 0; i < data.Count(); i++)
            {
                insertHolidays(data.ElementAt(i).Date, data.ElementAt(i).Day, data.ElementAt(i).HolidayName, data.ElementAt(i).isActive, data.ElementAt(i).currentYear, data.ElementAt(i).isHolidayWeekend, data.ElementAt(i).OfficialID);
            }
            return true;
        }
