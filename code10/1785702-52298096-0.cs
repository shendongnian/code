    protected void ButtonLogin_Click1(object sender, EventArgs e)
    {
        //Don't re-use the connection object. 
        // ADO.Net has a feature called connection pooling, and re-using the 
        // connection object interferes with it.
        // This is the rare case where you really do want to create
        // a new instance almost every time
        string checkuser = "select Role, Salt, PwdHash from [reg] where Username = @Username";
        string role = "", goodHash = "", salt = "";
        
        //The using blocks will make sure the connection is closed, 
        // **even if an exception is thrown**
        using (var con = new SqlConnection("Connection string here"))
        using (var cmd = new SqlCommand(checkuser, con))
        { 
            //**ALWAYS** use parameters like this to include data in the query that
            // has any chance to be influenced in any way by the user
            cmd.Parameters.Add("@Username",SqlDbType.NVarChar, 50).Value = TextBoxUser.Text;
            con.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                if (!rdr.Read()) // no record for this user
                {
                    //Common practice is to NOT make it obvious whether the username or password was wrong,
                   // though there is debate in security circles whether that's really necessary.
                   //Also, **DON'T USE MESSAGEBOX IN WEB APPS!**
                   // It doesn't work at all the way you think. 
                   Response.Redirect("InvalidLogin.aspx");
                   return;
               }
               //For convenience, I'll assume nothing is NULL if we actually have a record
               //Done right, the salt and password are often byte arrays, but base64 strings are common, too.
               salt = (string)rdr["Salt"]; 
               goodHash = (string)rdr["PwdHash"];
               role = (string)rdr["Role"];
            }
        }
        //You'll need to write this function on your own,
        // but there are libraries on NuGet that make it easy
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
