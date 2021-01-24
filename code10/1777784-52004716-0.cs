	using NetCoreWebApplication1.Dto;
	using NetCoreWebApplication1.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	namespace NetCoreWebApplication1.Other
	{
		public static class Extension
		{
			public static EmployeeForShortDto MapToEmployeeForShortDto(this Employee emp)
			{
				if (emp != null)
				{
					return new EmployeeForShortDto
					{
						Id = emp.Id,
						EmpCode = emp.EmpCode,
						Fname = emp.Fname,
						Lname = emp.Lname,
						Age = emp.DateBirth.CalcAge()
					};
				}
				return null;
			}
			public static EmployeeForListDto MapToEmployeeForListDto(this Employee emp)
			{
				if (emp != null)
				{
					return new EmployeeForListDto
					{
						Id = emp.Id,
						EmpCode = emp.EmpCode,
						Fname = emp.Fname,
						Lname = emp.Lname,
						Age = emp.DateBirth.CalcAge(),
						EntityCode = emp.EntityCode,
						IsActive = emp.IsActive
					};
				}
				return null;
			}
			public static Employee MapFromEmployeeForAddDto(this EmployeeForAddDto emp)
			{
				if (emp != null)
				{
					return new Employee
					{
						EmpCode = emp.EmpCode,
						Fname = emp.Fname,
						Lname = emp.Lname,
						IdCard = emp.IdCard,
						IsActive = 1
					};
				}
				return null;
			}
			public static int CalcAge(this DateTime? dateBirth)
			{
				if (dateBirth.HasValue)
				{
					var age = DateTime.Today.Year - dateBirth.Value.Year;
					if (dateBirth.Value.AddYears(age) > DateTime.Today) age--;
					return age;
				}
				else
				{
					return 0;
				}
			}
		}
	}
