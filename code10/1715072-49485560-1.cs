    SqlParameter[] param= new SqlParameter[4];
    param[0] = new SqlParameter("@ID", ID);
    param[1] = new SqlParameter("@Name", name);
    param[2] = new SqlParameter("@Gender", gender);
    param[3] = new SqlParameter("@TotalMarks", marks);
    RunQuery("updateStudent", param);
