    string s = "";
    SqlConnection conn = new SqlConnection("Server=192.168.1.1;Database=master;Connect Timeout=30;User ID=foobar;Password=raboof;");
    SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 5 name, dbid FROM sysdatabases", conn);
    DataTable dt = new DataTable();
    
    da.Fill(dt);
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        s += dt.Rows[i]["name"].ToString() + " -- " + dt.Rows[i]["dbid"].ToString() + "\n";
    }
    
    MessageBox.Show(s);
