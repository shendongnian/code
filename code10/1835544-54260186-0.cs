    public class ClassForResults(){
        public int UserID { get; set; };
        public string User { get; set; }
    }
    
    public IActionResult Search ([FromRoute]string input)
    {
        string sqlcon = _iconfiguration.GetSection("ConnectionStrings").GetSection("StringName").Value;
    
        List<ClassForResults> results = new List<ClassForResults>();
    
        using (var con = new SqlConnection(sqlcon))
        {
            using (var cmd = new SqlCommand()
                                 {
                                       CommandText = "SELECT u.UserID, u.User FROM [dbo].[Users] u WHERE User = 'Value';",
                                       CommandType = CommandType.Text,
                                       Connection = con
                                 })
            {
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassForResults result = new ClassForResults();
                        result.UserID = reader.GetInt(0);
                        result.User = reader.GetString(1);
                        results.Add(result);
                    }
    
                    con.Close();
    
                    return Ok(new Search(results));
                }
            }
        }
    }
