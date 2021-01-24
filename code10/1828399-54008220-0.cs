    private void SQLToCSV(string query, string Filename)
        {
        
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader result = cmd.ExecuteReader();
        
            using (System.IO.StreamWriter fs = new System.IO.StreamWriter(Filename))
            {
                // Loop through the fields and add headers
                for (int i = 0; i < result.FieldCount; i++)
                {
                    string colval = result.GetColumnName(i);
                    if (colval.Contains(","))
                        colval = "\"" + colval + "\"";
        
                    fs.Write(colval + ",");
                }
        //CONCATENATE THE COLUMNS YOU WANT TO ADD IN RESULT HERE
 
                fs.WriteLine();
               // Loop through the rows and output the data
                while (result.Read())
                {
                    for (int i = 0; i < result.FieldCount; i++)
                    {
                        string value = result[i].ToString();
                        if (value.Contains(","))
                            value = "\"" + value + "\"";
        
                        fs.Write(value + ",");
                    }
                    fs.WriteLine();
                }
        
                fs.Close();
            }
        }
