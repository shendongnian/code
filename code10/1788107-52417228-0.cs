    conn.Open();
                        SqlCommand cmd = new SqlCommand("Select ZoneID from Zones", conn);
                        SqlDataReader myReader = cmd.ExecuteReader();
        List<int> zoneIDs = new List<int>();
                            while (myReader.Read())
                            {
                                zoneIDs.Add(Convert.ToInt32(myReader["ZoneID"]));
                            }
                            cmd.Dispose();
                            myReader.Close();
        
                            foreach (int zones in zoneIDs)
                            {
        
                                int Zone_ID = zones;
                            }
