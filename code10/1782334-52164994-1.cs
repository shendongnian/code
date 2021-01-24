    var sql = new StringBuilder("insert into [").Append(TableName)
                  .Append("] values(");
    foreach (var item in ControlName.Controls)
    {
        if (item is TextBox)
        {
            cmd.Parameters.AddWithValue("@" + ((TextBox)item).ID, ((TextBox)item).Text);
            sql.Append("@").Append(((TextBox)item).ID).Append(",");
        }
    }
    cmd.CommandText = sql.Append(")").ToString();
