    while (sqlReader.Read())
    {  
        comboBox2.Items.Add(sqlReader.GetName(0));
    }
    sqlReader.Close();
    con6.Close();
