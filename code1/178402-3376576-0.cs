    string sql = "SELECT * FROM [table] WHERE [column] = @value";
    using (var cn = new SqlConnection("connection string here"))
    using (var cmd = new SqlCommand(sql, cn)
    {
        cmd.Parameters.Add("@value").Value = "'';DROP Table Users;--";
        cn.Open();
        SomeControl.DataSource = cmd.ExecuteReader();
        SomeControl.DataBind();
    }
