	public static TermRegistration GetLatestRegistration(this Student student)
	{
		Contract.Requires(student != null);
		return student.TermRegistrations.AsQueryable()
			.OrderByTerm()
			.FirstOrDefault();
	}
