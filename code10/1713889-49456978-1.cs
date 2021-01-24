	var interfaceList = new List<Type>();
	foreach (var restriction in constraint.GetGenericParameterConstraints())
	{
			if (restriction.IsClass)
			{
					constraintBuilder.SetBaseTypeConstraint(restriction);
			}
			else
			{
					interfaceList.Add(restriction);
			}
	}
	if (interfaceList.Count > 0)
	{
			constraintBuilder.SetInterfaceConstraints(interfaceList.ToArray());
	}
