    public List<ClassModel> GetClass(string ClassID)
    {
        List<ClassModel> students = new List<ClassModel>();
        SqlCommand cmd = new SqlCommand("sp_ABEAttendanceEnrollment", ABEAttendanceDB);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ClassID", ClassID);
        ABEAttendanceDB.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
    
        while (rdr.Read())
        {
            ClassModel student = new ClassModel();
            student.ClassID = rdr["ClassID"].ToString();
            student.SID = rdr["SID"].ToString();
            student.FullName = rdr["FullName"].ToString();
            students.Add(student);
        }
    
        ABEAttendanceDB.Close();
        return students;
    }
