	// how to get data further?
	var allDependents = q.Elements("Dependents").Elements("Dependent");
	foreach (var b in allDependents)
	{
		Dependents d = new Dependents
		{
			age = Convert.ToInt32(b.Element("age").Value),
			name = b.Element("name").Value
		};
		obj.Dependents.Add(d);
	}
	obj.Department.DeptId = Convert.ToInt32(q.Element("Department").Element("DeptId").Value);
	obj.Department.DeptName = q.Element("Department").Element("DeptName").Value;
