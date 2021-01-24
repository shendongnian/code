    foreach (var item in ControlName.Controls)
    {
        if (item is TextBox)
        {
            cmd.Parameters.AddWithValue("@" + ((TextBox)item).ID, ((TextBox)item).Text);
            values += "@" + ((TextBox)item).ID + ",";
        }
    }
    cmd.CommandText = "insert into "+ TableName +" values(" + values + ")";
