    try
    {
      Guid newGuid = Guid.NewGuid();
      SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
      conn.Open();
      string insertQuery = @"if not exists (select * from UsrData where UserName = @Uname)
        insert into UsrData (Id, UserName, Email, Password, Country) values (@id, @Uname, @email, @password, @country)";
      SqlCommand com = new SqlCommand(insertQuerey, conn);
        com.Parameters.AddWithValue("@id", newGuid);
        com.Parameters.AddWithValue("@Uname", TextBoxUN.Text);
        com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
        com.Parameters.AddWithValue("@password", TextBoxPass.Text);
        com.Parameters.AddWithValue("@country", DropDownListCountry.SelectedItem.ToString());
        com.ExecuteNonQuery();
        Response.Redirect("login.aspx");
        Response.Write("Sucessuflly registred");
        conn.Close();
    }
    catch (Exception ex)
    {
        Response.Write("An unknown error " + ex.ToString());
    }
    
