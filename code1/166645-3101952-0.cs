    string sql = "SELECT * FROM Employee e INNER JOIN Clock_History c ON c.Badge = e.Badge WHERE e.Badge = @BadgeID";
    using (var cn = new OracleConnection("your connection string here"))
    using (var cmd = new OracleCommand(sql, cn))
    {
        cmd.Parameters.Add("@BadgeID", OracleDbType.Int).Value = Badge;
        cn.Open();
        xHoursGridView.DataSource = cmd.ExecuteReader();
        xHoursGridView.DataBind();
    }
