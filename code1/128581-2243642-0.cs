                // Read from file
                FileStream fs;
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);           
    
                // Conver to binary
                byte[] binaryData = new byte[fs.Length];
                fs.Read(binaryData, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
    
    
                // insert into DB
                string connstr = @"Data Source=.;Initial Catalog=TestImage;
                    Persist Security Info=True;User ID=sa";
    
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
    
                string query = "insert into test_table(binaryCoulumn) values(" + binaryData + "+)";
    
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Binary;
                parameter.ParameterName = "binaryCoulumn";
                parameter.Value = binaryData;
 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(parameter);
                cmd.ExecuteNonQuery();         
    
                cmd.Dispose();
                conn.Close();
                conn.Dispose(); 
