    //dynamic item = new ExpandoObject();
    Dictionary<string, object> item = new Dictionary<string, object>();
	for(int i=0;i<20;i++)
	{
		if(x[i].ToString().Contains(","))
		{
			Dictionary<string, object> temp = new Dictionary<string, object>()
			string[] data = x[i].ToString().Split(',');
			for(int j=0;j<data.Length;j++)
			{
				temp.Add(rdr.GetName(i)+j, data[j]);
			}
			item.Add(rdr.GetName(i), temp);
		}
		else
		{
		 item.Add(rdr.GetName(i), x[i]);
		 Console.WriteLine("\n");
		}
	}
