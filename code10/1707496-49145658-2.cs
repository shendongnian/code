	if (reader.HasRows)
	{
		while (reader.Read())
		{
			Console.WriteLine("\t{0}\t{1}", reader[0].ToString(),
			reader[1].ToString());
		}
	}
	else
	{
		return "Data is Empty";
	}
