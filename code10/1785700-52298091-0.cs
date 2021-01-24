    string getUserRole = "SELECT Role from [reg] where Username= @User";
    Using;
        SqlCommand sqlCmd = new SqlCommand(sql, con);
        sqlCmd.Parameters.Add("@User", SqlDbType.String).Value = TextBoxUser.Text;
        String userRole = roleCmd.ExecuteScalar().ToString().Replace(" ","");
    End Using;
    con.Close();
    if userRole = your_user_role
        //redirect 1
    else
       // redirect 2    
        
