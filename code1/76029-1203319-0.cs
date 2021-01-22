	public static class DataRecordHelper
	{
		public static void CreateRecord<T>(IDataRecord record, T myClass)
		{
			PropertyInfo[] propertyInfos = typeof(T).GetProperties();
			for (int i = 0; i < record.FieldCount; i++)
			{
				foreach (PropertyInfo propertyInfo in propertyInfos)
				{
					if (propertyInfo.Name == record.GetName(i))
					{
						propertyInfo.SetValue(myClass, Convert.ChangeType(record.GetValue(i), record.GetFieldType(i)), null);
						break;
					}
				}
			}
		}
	}
	public class Employee
	{
		public int Id { get; set; }
		public string LastName { get; set; }
		public DateTime? BirthDate { get; set; }
		public static IDataReader GetEmployeesReader()
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
			conn.Open();
			using (SqlCommand cmd = new SqlCommand("SELECT EmployeeID As Id, LastName, BirthDate FROM Employees"))
			{
				cmd.Connection = conn;
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
		}
		public static IEnumerable GetEmployees()
		{
			IDataReader rdr = GetEmployeesReader();
			while (rdr.Read())
			{
				Employee emp = new Employee();
				DataRecordHelper.CreateRecord<Employee>(rdr, emp);
				yield return emp;
			}
		}
	}
