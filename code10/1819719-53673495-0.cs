    protected void Button2_Click(object sender, EventArgs e)
    {
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\SPECIFY HERE\\LOG_TEST.xlsx" + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
     string query ="INSERT INTO [Sheet1$] (NAME, Mobile, Emails) VALUES ('Bob', '1', 'Whatever@mail')";
     OleDbConnection con = new OleDbConnection(connString);
     OleDbCommand cmd = new OleDbCommand(query, con);
     con.Open();
     cmd.ExecuteNonQuery();
     
    }
