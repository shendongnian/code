    SqlConnection conn   = null;
    SqlDataReader reader = null;
    //Connection string goes here
    
    string studentName = byNametextBox.Text;
    SqlCommand cmd = new SqlCommand(
		"SELECT * FROM Guests "+" WHERE Students.name = @name", conn);
    SqlParameter param  = new SqlParameter("@name", SqlDbType.NVarChar, 50);
    param.Value = studentName;
    cmd.Parameters.Add(param);
    reader = cmd.ExecuteReader();
    //Do stuff with reader here
