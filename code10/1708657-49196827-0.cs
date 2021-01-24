	DateTime? date=null;
	DateTime? DueDate = null;
	string OriginalOrderNumber = null;
	string FirstName=null;
	string LastName = null;
	string email = null;
	string StreetA = null;
	string StreetB = null;
	string PostalCode = null;
	string City = null;
	string State_id = null;
	string country_code = null;
	string phone = null;
	XmlTextReader reader = new XmlTextReader("ecom_MailInArt_Store.xml");
	while (reader.Read())
	{
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:order"))
		{
			if (reader.HasAttributes)
			{
				OriginalOrderNumber = reader.GetAttribute("OriginalOrderNumber");
			}
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:CreateDate"))
		{
			reader.Read();
			date = Convert.ToDateTime(reader.Value);
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:DueDate"))
		{
			reader.Read();
			DueDate = Convert.ToDateTime(reader.Value);
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:FirstName"))
		{
			reader.Read();
			FirstName = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:LastName"))
		{
			reader.Read();
			LastName = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:customer-email"))
		{
			reader.Read();
			email = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:phone"))
		{
			reader.Read();
			phone = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:StreetA"))
		{
			reader.Read();
			StreetA = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:StreetB"))
		{
			reader.Read();
			StreetB = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:PostalCode"))
		{
			reader.Read();
			PostalCode = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:City"))
		{
			reader.Read();
			City = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:State_id"))
		{
			reader.Read();
			State_id = reader.Value;
		}
		if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ns:country-code"))
		{
			reader.Read();
			country_code = reader.Value;
		}
	}
	SqlConnection con = new SqlConnection("Data Source=MNGNET320543D;Initial Catalog=excercise1;User id=sa;Password=Infosys123;");
	SqlCommand cmd = new SqlCommand("Insert into MailInArtOrder(OrderNumber,OrderCreateDate,DueDate,FirstName,LastName,EmailAddress,PhoneNumber,StreetA,StreetB,PostalCode,City,State,CountryCode) values(@OrderNumber,@OrderCreateDate,@DueDate,@FirstName,@LastName,@EmailAddress,@PhoneNumber,@StreetA,@StreetB,@PostalCode,@City,@State,@CountryCode)", con);
	cmd.Parameters.AddWithValue("@OrderNumber", OriginalOrderNumber);
	cmd.Parameters["@OrderNumber"].Value = OriginalOrderNumber;
	cmd.Parameters.AddWithValue("@OrderCreateDate", date);
	cmd.Parameters.AddWithValue("@DueDate", DueDate);
	cmd.Parameters.AddWithValue("@FirstName", FirstName);
	cmd.Parameters.AddWithValue("@LastName", LastName);
	cmd.Parameters.AddWithValue("@EmailAddress", email);
	cmd.Parameters.AddWithValue("@PhoneNumber", phone);
	cmd.Parameters.AddWithValue("@StreetA", StreetA);
	cmd.Parameters.AddWithValue("@StreetB", StreetB);
	cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
	cmd.Parameters.AddWithValue("@City", City);
	cmd.Parameters.AddWithValue("@State", State_id);
	cmd.Parameters.AddWithValue("@CountryCode", country_code);
	try
	{
		con.Open();
		SqlDataReader reader1 = cmd.ExecuteReader();
		Console.WriteLine("Record inserted");
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
