     public Report Create(Area area, DateTime date, Shift shift)
        {
		DateTime startDate = new DateTime(date.Year, date.Month, date.Day);
		startDate.AddHours(shift.Time.Hour);
		startDate.AddMinutes(shift.Time.Minute);
		return Persistence.DataManager.CreateReport(area, startDate);
        }
