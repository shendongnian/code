    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public List<Employee> LoadEmployees(string category)
    {
        var query = 
    "SELECT employee_id, employee_name FROM employees WHERE employee_category=@category";
        var parameter = new SqlParameter
        {
            ParameterName = "@category",
            SqlDbType = SqlDbType.Varchar,
            Value = category
        };
        var employees = new List<Employee>();
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(query, connection))
        {
            connection.Open();
            command.Parameters.Add(parameter);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                    employees.Add(employee);
                }
            }
            return employees;
        }
    }
