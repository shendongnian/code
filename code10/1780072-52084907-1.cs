    public StudentModel GetStudent(StageModel model)
    {
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LO"].ConnectionString))
        {
            string getstudent=  @"select s.*, c.ClassId, c.ClassName from student s
                                 INNER JOIN class c on s.classid = c.classid 
                                 and s.studentid = @studentid;";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@studentid", model.Student_Id, DbType.Int64);
            connection.Open();
    
            result = connection.Query<StudentModel, ClassModel, StudentModel>
                     (getstudent, ((s, c) => { s.ClassModel = c; return s;}), 
                     splitOn:"ClassId", parameter);
    
            return result;
        }
    }
