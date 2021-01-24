    [HttpPost]
    public JsonResult AjaxMethodSaveStudent(string cboStudentName = "", string cboStudentSurname = "", string txtStudentMiddleName = "", string txtStudentNumber = "", string txtStudentDOB = "", string txtStudentPreferredName = "", string txtStudentPropertyName = "", string txtStudentRegImmiCardNumber = "")
    {
        long studentId = 0;
        string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        string queryStudent = 
           "INSERT INTO `STUDENT REGISTER` " +
                 "(`first name`, `surname`, `Middle Names`,`DATE OF BIRTH`, `ImmiCardNumber`) " +
           "VALUES (@StudentName, @Surname, @MiddleName, @DOB, @ImmiCardNumber);";
        using (MySqlConnection con = new MySqlConnection(constr))
        using (MySqlCommand cmd = new MySqlCommand(queryStudent, con))
        {
            //Use actual types and lengths from the database here.
            // Do NOT use AddWithValue() to skip setting parameter types.
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar, 30).Value = cboStudentName;
            cmd.Parameters.Add("@Surname", MySqlDbType.VarChar, 30).Value = cboStudentSurname;
            cmd.Parameters.Add("@MiddleName", MySqlDbType.VarChar, 30).Value = txtStudentMiddleName;
            cmd.Parameters.Add("@DOB", MySqlDbType.DateTime).Value =  (txtStudentDOB.Length > 2) ? DateTime.Parse(txtStudentDOB.Substring(6, 4) + "-" + txtStudentDOB.Substring(3, 2) + "-" + txtStudentDOB.Substring(0, 2)) : (object)DBNull.Value;
            cmd.Parameters.Add("@ImmiCardNumber", MySqlDbType.VarChar, 30).Value = txtStudentRegImmiCardNumber;
            con.Open();
            cmd.ExecuteNonQuery();
            studentId = cmd.LastInsertedId;
        }
        
        return Json(new { success = true, studentId = studentId }, JsonRequestBehavior.AllowGet);
    }
