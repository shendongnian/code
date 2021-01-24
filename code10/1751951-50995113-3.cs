    foreach (string Shipment in Shipments)
    {
         res r = new res(Shipment, DateTime.Now);
         using (SqlCommand cmd = new SqlCommand(sql, cnn))
         {
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@ShipmentId", Shipment);
               cmd.Parameters.AddWithValue("@OfficeId", "swe");
               cmd.Parameters.AddWithValue("@Dbg", "1");
