    protected void ButtonLogin_Click1(object sender, EventArgs e)
    {
        string checkuser = "select Role, Salt, PwdHash from [reg] where Username = @Username";
        string role = "", goodHash = "", salt = "";
        
        using (var con = new SqlConnection("Connection string here"))
        using (var cmd = new SqlCommand(checkuser, con))
        { 
            cmd.Parameters.Add("@Username",SqlDbType.NVarChar, 50).Value = TextBoxUser.Text;
            con.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                if (!rdr.Read()) // no record for this user
                {
                   Response.Redirect("InvalidLogin.aspx");
                   return;
                }
                salt = (string)rdr["Salt"]; 
                goodHash = (string)rdr["PwdHash"];
                role = (string)rdr["Role"];
            }
        }
        // You still need to write your own bcrypt function
        var attemptedHash = GetBCryptHash(salt, TextBoxPass.Text);
        if (attemptedHash != goodHash)
        {
            Response.Redirect("InvalidLogin.aspx");
            return;
        }
        Session["New"] = TextBoxUser.Text;
        Session["Username"] = TextBoxUser.Text;
        Session["Role"] = role;
        if (role == "Teacher")
        {
            Response.Redirect("HomeTeacher.aspx");
        }
        else
        {
            Response.Redirect("HomeStudent.aspx");
        }
    }
