	class TableData
	{
		public string TableName;
		public object[] Data;
	}
	class Employee
	{
		public string EmployeeName;
		public int Salary;
		public string Department;
	}
	class Student
	{
		public int StudentID;
		public string Name;
		public int Marks;
		public string Grade;
	}
	
	static void Main(string[] args)
	{
		var jsondataset = @"
			[
				{
					'TableName': 'Employee',
					'Data': [
						{
							'EmployeeName': 'John',
							'Salary': 5000,
							'Department': 'Marketing'
						},
						{
							'EmployeeName': 'Smith',
							'Salary': 4000,
							'Department': 'IT'
						},
						{
							'EmployeeName': 'Williams',
							'Salary': 6000,
							'Department': 'Sales'
						},
						{
							'EmployeeName': 'Vijay',
							'Salary': 6500,
							'Department': 'IT'
						}
					]
				},
				{
					'TableName': 'Student',
					'Data': [
						{
							'StudentID': 1,
							'Name': 'Suresh',
							'Marks': 950,
							'Grade': 'A+'
						},
						{
							'StudentID': 1,
							'Name': 'Rama',
							'Marks': 900,
							'Grade': 'A+'
						},
						{
							'StudentID': 1,
							'Name': 'Kishore',
							'Marks': 750,
							'Grade': 'B'
						}
					]
				}
			]
		";
		
		JavaScriptSerializer json_serializer = new JavaScriptSerializer();
		var datasets = json_serializer.Deserialize<TableData[]>(jsonString);
		foreach (var dataset in datasets)
		{
			switch (dataset.TableName)
			{
				case "Student":
					foreach (var person in dataset.Data)
					{
						var student = json_serializer.ConvertToType<Student>(person);
						Console.WriteLine("Student " + student.Name + " has grade " + student.Grade);
					}
					break;
				case "Employee":
					foreach (var person in dataset.Data)
					{
						var employee = json_serializer.ConvertToType<Employee>(person);
						Console.WriteLine("Employee " + employee.EmployeeName + " has grade " + employee.Salary);
					}
					break;
				default:
					Console.WriteLine("Unknown datatable");
					break;
			}
		}
	}
