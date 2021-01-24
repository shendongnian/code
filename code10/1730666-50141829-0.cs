    public class Employee
    {
        public string Name {get;set;}
        public string code {get;set;}
        public bool Left {get;set;}
    }
    // ...
    public IEnumerable<Employee> GetEmployees(bool Left)
    {
        string sql = "Select code,Name,Left from employee where Left= @Left";
        using (var cn = new SqlConnection("<CONNECTION STRING>"))
        using (var cmd = new SqlCommand(sql, cn))
        {
            cmd.Parameters.Add("@Left", SqlDbType.Char, 1).Value = Left?"Y":"N";
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while(rdr.Read())
                {
                    yield return new Employee() {
                        Name = rdr["Name"], 
                        code = rdr["code"], 
                        Left = (rdr["Left"] == "Y")?true:false
                    };
                }
                rdr.Close();
            }
        }
    }
        // ...
        var employees = GetEmployees(true);
        foreach (var e in employees)
        {
            Response.Write("<span>{0}</span><span>{1}</span><span>{2}</span>", e.Name, e.code, e.Left );
        }
