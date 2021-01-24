    string insertCommand = "INSERT INTO students VALUES (@stuID, @stuName, @stuAge, @stuSemester, @stuCity)";
    insertCommand.Parameters.Add(new SqlParameter("stuId", stu_ID.Text));
    command.Parameters.Add(new SqlParameter("stuName", stu_Name.Text));
    command.Parameters.Add(new SqlParameter("stuAge", Convert.ToInt32(stu_Age.Text)));
    command.Parameters.Add(new SqlParameter("stuSemester", Convert.ToInt32(stu_Semester.Text)));
    command.Parameters.Add(new SqlParameter("stuCity", stu_City.Text));
     
