    class Program
	{
		static void Main(string[] args)
		{
			Company comp = new Company();
			//Somecode
		}
	}
	class Company
	{
		public List<Employee> employees = new List<Employee>();
		public void Hire(Employee emp)
		{
			employees.Add(emp);
		}
		public void ListEmployees()
		{
			foreach (Employee emp in employees)
			{
				Console.WriteLine(emp);
			}
		}
	}
