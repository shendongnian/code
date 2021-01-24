    public static void SQLLoop()
    {
        List<string> shipments = new List<string>();
        string sql = "adsffo;hkjasd";
        using (SqlConnection cnn = new SqlConnection("asfd"))
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, cnn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                List<res> results = new List<res>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramShipment = new SqlParameter("@ShipmentId", SqlDbType.VarChar, 100);
                cmd.Parameters.Add(paramShipment);
                cmd.Parameters.AddWithValue("@OfficeId", "swe");
                cmd.Parameters.AddWithValue("@Dbg", "1");
                foreach (string shipment in shipments)
                {
                    res r = new res(shipment, DateTime.Now);
                    paramShipment.Value = shipment;
                    string invoice = cmd.ExecuteScalar().ToString();
                    r.Sl = DateTime.Now;
                    TimeSpan timeDiff = r.St - r.Sl;
                    r.Exectimems = timeDiff.TotalMilliseconds;
                    results.Add(r);
                    Console.WriteLine(shipment, r.Exectimems.ToString());
                }
            }
        }
    }
