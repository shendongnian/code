    int value1 = 0;
    int value2 = 0;
    if (int.TryParse(a.Text, out value1 ) && int.TryParse(HITEM.Text, out value2))
    {
       // if  valid
        mysqlcmd6.Parameters.Add("@main_items_id_",  MySqlDbType.Int32).Value =  value1;
        mysqlcmd6.Parameters.Add("@res", MySqlDbType.Int32).Value = value2;
    }
    else
    {
       // if  invalid
       //throw exception or return
    }
