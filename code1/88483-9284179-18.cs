	public static TermRegistration GetLatestRegistration(this Student student)
	{
		return student.TermRegistrations.AsQueryable()
			.OrderByTerm()
			.FirstOrDefault();
	}
