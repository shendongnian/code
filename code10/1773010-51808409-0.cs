    public List<ClsHorseTracker> HorseTrackerList()
            {
             clsUtilities clsUtilities = new clsUtilities();
               DataSet ds;
               List<ClsHorseTracker> clsHorseTracker = new List<ClsHorseTracker>();
    
                string sSQL;
                sSQL = "exec HorseDetails";
                ds = clsUtilities.GetDataSet(sSQL);
    
                SqlCommand cmd = new SqlCommand();
    
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            clsHorseTracker.Add(new ClsHorseTracker
                            {
    
                                HorseName = Convert.ToString(reader["HorseName"]),
                                HorseTypeName = Convert.ToString(reader["HorseTypeName"]),
    
                            });
                        }
                    }
    
    
                }
    
    
                return clsHorseTracker;
            }
