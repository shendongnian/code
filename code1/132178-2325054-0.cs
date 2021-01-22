    public DataSet GetData(string serverName,string dataBaseName)
    {
        SqlCommand cmd;
        SqlDataAdapter ada;
        DataSet ds = new DataSet();
        SqlConnection Con;
    
        Con = New SqlConnection("Data Source='" & serverName & "';Initial  Catalog='"  & dataBaseName & "';Integrated Security=true");
         Con.Open();
    
            cmd = New SqlCommand("Select * from tb1", Con);
            ada = New SqlDataAdapter(cmd);
            ada.Fill(ds, "tb1");
            return ds;
    }
