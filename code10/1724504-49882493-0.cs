    string name = null;
    using(var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            string name = reader[0] as String;
            break;
        }
    }
    label2.Text = name;
