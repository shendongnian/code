    string val="";
	if (reader.HasRows)
	{
		while (reader.Read())
		{
            val += "ID = " + reader[0].ToString() + "; Name = " + reader[1].ToString();
		}
	}
	else
	{
		return "Data is Empty";
	}
    reader.Close();
    return val;
