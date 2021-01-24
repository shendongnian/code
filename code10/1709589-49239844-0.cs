    public Dictionary<string, List<Attendance>> GetAttendanceLastMonth(string schoolId, params string[] classIds)
	{
		DateTime monthStart = DateTime.Today.AddDays(-DateTime.Today.Day);
		DateTime nextMonthStart = monthStart.AddMonths(1);
		Dictionary<string, List<Attendance>> attendancesDictionary = Repository
			.Where(x => x.SchoolId.Equals(schoolId))
			.Where(x => classIds.Contains(x.ClassId))
			.Where(x => x.AttendanceDate.Date >= monthStart && x.AttendanceDate.Date < nextMonthStart)
			.GroupBy(x => x.ClassId)
			.ToDictionary(g => g.Key, g => g.OrderBy(x => x.AttendanceDate).ToList());
		return attendancesDictionary;
	}
