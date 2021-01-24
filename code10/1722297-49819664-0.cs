             //Open connection
            using (SqlConnection DBConnection = new SqlConnection(connectionString))
            {
                DBConnection.Open();
                //System.Diagnostics.Debug.WriteLine( "SQL : " + query );
                //Create Command
                using (SqlCommand cmd = new SqlCommand(query, DBConnection))
                {
                    //Create a data reader and Execute the command                    
                    //Read the data and store them in the list 
                    List<Dictionary<string, object>> ResultsSet = null;//Create a list to store the result
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        ResultsSet = new List<Dictionary<string, object>>();
                        while (dataReader.Read())
                        {
                            Dictionary<string, object> ROW = new Dictionary<string, object>();
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                if (dataReader[i].GetType().ToString() == "System.Byte[]")
                                {
                                    ROW.Add(dataReader.GetName(i), (byte[])dataReader[i]);
                                }
                                else
                                {
                                    ROW.Add(dataReader.GetName(i), dataReader[i] + string.Empty);
                                }
                            }
                            ResultsSet.Add(ROW);
                        }
                    }
                    DBConnection.Close();
                    return ResultsSet;
                }
            }           
        }
