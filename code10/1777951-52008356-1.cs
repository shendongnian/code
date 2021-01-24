    public List<Summary> EmpSum
		{
			get
			{
				return this.Employees.GroupBy(x => x.Title).Select(y => new Summary { Title = y.First().Title, MathSalary = y.Where(s => s.Department == "Math").Sum(s => s.Salary), CompSciSalary = y.Where(s => s.Department == "CompSci").Sum(s => s.Salary), Total = y.Sum(s => s.Salary) }).ToList();
			}
		}
