    String query = @"select count (*) from USERINFO 
                     where USERID=@uid and USERNAME=@name and MVerifyPass=@pass";
    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Convert.ToInt32(textuserid.Value);
    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textusername.Text;
    cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = textpassword.Text;
    String output = cmd.ExecuteScalar().ToString();
    if (output == "1")
    {
        Session["userid"] = textuserid.Value;
        Session["User"] = textusername.Text;
        Response.Redirect("~/app/Dashboard.aspx");
    }
    else
    {
        Response.Write("Your User ID and Password is wrong!");
    }
