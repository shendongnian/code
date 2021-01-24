	foreach(var emp in obj2.employees)
	{
		Employee existing = null;
		try
		{
			existing = obj1.employees.SingleOrDefault(e => e.firstName == emp.firstName);
		} 
		catch(Exception ex)
		{
			// The same employee exists multiple times in the first list
		}
		
		if(existing != null)
		{
			// obj1 already contains an employee with the given name, check which value is bigger
			if(existing.HighValue < emp.HighValue)
			{
				// The value of the existing employee is smaller 
				// -> Update the value with the value from the second object
				existing.HighValue = emp.HighValue;
			}
		}
		else
		{
			// obj1 does not already contain an employee with the given name, add the whole employee
			obj1.employees.Add(emp);
		}
	}
