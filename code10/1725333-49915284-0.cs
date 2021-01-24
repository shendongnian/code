	public List<Customer> GetCustomer()
	{
		Connection con = new Connection();
		con.Start();
		DataTable dt = con.Select("Select  ID,Picture ,Customer_Name,Contact_No,Time_In from Customers_Data WHERE   ( Date >= dateadd(day,datediff(day,7,GETDATE()),0)  AND  Date < dateadd(day,datediff(day,0,GETDATE()),1)) And (Sale_Made='No') ");
		con.Stop();
		List<Customer> ro = new List<Customer>();
		foreach (DataRow item in dt.Rows)
		{
			string filePath = item["Picture"].ToString();
			FileStream fs = new FileStream(filePath, FileMode.Open);
			byte[] result;
			using (Stream stream = fs)
			{
				using (var memoryStream = new MemoryStream())
				{
					stream.CopyTo(memoryStream);
					result = memoryStream.ToArray();
					// ProfilePicture = result,
				}
			}
			ro.Add(new Customer { Id = item["ID"].ToString(), ProfilePicture = result, Name = item["Customer_Name"].ToString(), Contact = item["Contact_No"].ToString(), Time_In = item["Time_In"].ToString() });
		}
		return ro;
	}
