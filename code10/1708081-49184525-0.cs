     if (_SAPMembers == null)
{
	    List<SAPMember> _SAPMembers = new List<SAPMember>();
	var lookup = new Dictionary<string, SAPMember>();
	var result = DbConn.Query<SAPMember, CostCentre, SAPMember>(@"
	select DISTINCT e.EmployeeNo as EmployeeNumber, e.LastName, e.FirstName, c.EmployeeNo as EmpNo
	, c.CostCentreCode as Name, c.DivisionDescription as Division
	FROM EmployeeListing e
	join EmployeeListing c on e.EmployeeNo = c.EmployeeNo
	where e.TerminationDate is null and c.TerminationDate is null", (e, c) =>
	{
		if (!lookup.TryGetValue(e.EmployeeNumber, out SAPMember sapMember))
			lookup.Add(e.EmployeeNumber, sapMember = e);
		if (sapMember.CostCentres == null)
			sapMember.CostCentres = new List<CostCentre>();
		sapMember.CostCentres.Add(c);
		return sapMember;
	}, splitOn: "EmpNo");
	_SAPMembers = result.Distinct().ToList();
