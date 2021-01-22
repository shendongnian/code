	public static IOrderedQueryable<TermRegistration> ThenByStudentName(
		this IOrderedQueryable<TermRegistration> query)
	{
		return query
			.ThenBy(reg => reg.Student.FamilyName)
			.ThenBy(reg => reg.Student.GivenName);
	}
