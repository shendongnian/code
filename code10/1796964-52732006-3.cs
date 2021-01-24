                if (sdr.HasRows == true)
                {
                    string csv = string.Empty;
  
                    while (sdr.Read())
                    {
                        csv += sdr["sysproID"].ToString().Replace(",", ";") + ',';
                        // add other columns
                        csv += "\r\n";
                    }
                }
                //Download the CSV file.
