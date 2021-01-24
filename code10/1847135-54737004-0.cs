    [HttpGet]
    public ActionResult<StudentViewModel> GetAllStudents()
    {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
    
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "SELECT s.id, s.name, c.Name as courseName FROM Student s INNER JOIN Courses c on c.studentId = s.id";
                        cmd.Connection = connection;
                        
    
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                  
                        da.Fill(dataTable);
                        connection.Close();
                        da.Dispose();
    
                        //Fill result view model from dataTable which will contain all data which you want from DB. 
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
            }
    }
