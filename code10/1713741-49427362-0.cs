    String query = "SELECT * FROM Seller WHERE Login=@Login and Password=@Password";
    SqlCommand Sqlcmd = new SqlCommand(query, con1.con);
    Sqlcmd.CommandType = System.Data.CommandType.Text;
    Sqlcmd.Parameters.AddWithValue("@Login", login.Text);
    Sqlcmd.Parameters.AddWithValue("@Password", password.Password);
    DataTable dt = new DataTable();
    dt.Load(Sqlcmd.ExecuteReader());
    if (dt.Rows.Count == 1)
    {
        string name = dt.Rows[0]["Name"].ToString();
        //...
        MainWindow dashboard = new MainWindow();
        dashboard.Show();
            this.Hide();
    }
    ...
