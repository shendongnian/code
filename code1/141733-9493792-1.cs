    private void tbautocomplete_TextChanged(object sender, EventArgs e)
    {
        AutoCompleteStringCollection namecollection = new AutoCompleteStringCollection();
        SqlConnection con = new SqlConnection(@"Data Source=88888;Initial Catalog=contrynames;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT  distinct(person_Firstname+''+person_Lastname) AS name FROM persondetails WHERE name Like '%'+@name+'%'";
        con.Open();
        SqlDataReader rea = cmd.ExecuteReader();
        if (rea.HasRows == true)
        {
            while (rea.Read())
            namecollection.Add(rea["name"].ToString());            
        }
        rea.Close();
        tbautocomplete.AutoCompleteMode = AutoCompleteMode.Suggest;
        tbautocomplete.AutoCompleteSource = AutoCompleteSource.CustomSource;
        tbautocomplete.AutoCompleteCustomSource = namecollection;
