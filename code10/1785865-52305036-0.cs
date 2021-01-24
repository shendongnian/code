	Func<Func<ReportModel, bool>, string> toString = func => 
	{
		var vm = ((dynamic)func.Target).rec;
		var paramType = func.Method.GetParameters()[0].ParameterType;
		var firstNameProperty = paramType.GetProperties().First(p => p.Name == nameof(vm.Firstname)).Name;
		var surnameProperty = paramType.GetProperties().First(p => p.Name == nameof(vm.Surname)).Name;
		return $"(({paramType.Name}.{firstNameProperty} == \"{vm.Firstname}\") AndAlso ({paramType.Name}.{surnameProperty} == \"{vm.Surname}\"))";
	};
	
	Console.WriteLine(toString(exp(viewModel))); 
    //returns ((ReportModel.Firstname == "Peter") AndAlso (ReportModel.Surname == "Jones"))
