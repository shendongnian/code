    //Change #1 -- new type with space for each attribute
    public class Employee
    {
        public string Name {get;set;}
        public string code {get;set;}
        public bool Left {get;set;}
    }
    // ...
    public IEnumerable<Employee> GetEmployees(bool Left)
    {
        //Change #2 -- ask for other fields in the the SQL select clause
        string sql = "SELECT code, Name, Left FROM employee WHERE Left= @Left";
        using (var cn = new SqlConnection("<CONNECTION STRING>"))
        using (var cmd = new SqlCommand(sql, cn))
        {
            cmd.Parameters.Add("@Left", SqlDbType.Char, 1).Value = Left?"Y":"N";
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while(rdr.Read())
                {
                    //Change #3 -- use all fields from the query results 
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
        //Change #4 -- Write all fields to the response.
        Response.Write("<span>{0}</span><span>{1}</span><span>{2}</span>", e.Name, e.code, e.Left );
    }
