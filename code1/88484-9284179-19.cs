	public static IList<TermRegistration> GetByTerm(Term term, bool ordered)
	{
		var termReg = term.TermRegistrations;
		return (ordered)
			? termReg.AsQueryable().OrderByStudentName().ToList()
			: termReg.ToList();
	}
