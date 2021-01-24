    int value1 = 0;
    int value2 = 0;
    if (!Int32.Text.TryParse(a.Text) || !Int32.TryParse(HITEM.Text))
    {
		return;
    }
	 mysqlcmd6.Parameters.Add("@main_items_id_",  MySqlDbType.Int32).Value =  value1;
     mysqlcmd6.Parameters.Add("@res", MySqlDbType.Int32).Value = value2;
