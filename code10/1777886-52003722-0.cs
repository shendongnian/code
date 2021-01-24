    void Main()
    {
    	DataTable tbl = new DataTable();
    	using (SqlConnection con = new SqlConnection(@"server=.\SQLEXpress;Database=Northwind;Trusted_Connection=yes"))
    	{
    		con.Open();
    		var reader = new SqlCommand("select * from Orders",con).ExecuteReader();
    
    		while (reader.Read())
    		{
    			if ((Shipper)reader["ShipVia"] != Shipper.SpeedyExpress)
    			{
    				Console.WriteLine($@"{(int)reader["OrderId"]}, {(Shipper)reader["ShipVia"]}");
    			}
    		}
    	}
    	
    }
    
    public enum Shipper
    {
        None,
    	SpeedyExpress,
    	UnitedPackage
    } 
