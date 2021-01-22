    void CallMyStoredProcedure(string connectionString, string paramValue)
    {
        string spName = "MyStoredProcedure";
        string columnValue;
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(spName, conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            // Set parameter values
            cmd.Parameters.AddWithValue("@inputParam",
                (object)paramValue ?? DBNull.Value);
            // Parameter to store return value of your SP
            SqlParameter returnParam = cmd.Parameters.Add(
                new SqlParameter("RETURN_VALUE", SqlDbType.Int));
            returnParam.Direction = ParameterDirection.ReturnValue;
            // Execute SP and read results
            conn.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                // Do something with return value
                int? returnValue = cmd.Parameters["RETURN_VALUE"].Value as int?;
                while (dr.Read())
                {
                    // Suggested way to read results if you use
                    // "SELECT * FROM" in your SP. If you return columns
                    // in a fixed order, it's fairly safe to be reading
                    // in that order without looping
                    for (int field = 0; field < dr.FieldCount; field++)
                    {
                        switch (dr.GetName(field))
                        {
                            case "StringColumn":
                                columnValue = dr.GetValue(field) as string;
                                break;
                            default:
                                // Column not recognized by your code.
                                // You might choose to complain about it here.
                                break;
                        }
                    }
                }
            }
        }
    }
