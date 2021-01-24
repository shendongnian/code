     var bankParameter =
                       new SqlParameter("@BankType", SqlDbType.VarChar) { Value = "Checking" };
            var emailParameter =
                new SqlParameter("@VendorEmail", SqlDbType.VarChar) { Value = "vendorEmail@yahoo.com" };
            var idParameter =
                new SqlParameter("@ID", SqlDbType.Int32) { Value = 12345 };
            var conStr = "yourConnectionString";
            using (SqlConnection sConn = new SqlConnection(conStr))
            {
                using (SqlCommand sComm = new SqlCommand("TestStoredProc", sConn))
                {
                    sComm.CommandTimeout = 60;
                    sComm.CommandType = CommandType.StoredProcedure;
                    
                    sComm.Parameters.Add(bankParameter);
                    sComm.Parameters.Add(emailParameter);
                    sComm.Parameters.Add(idParameter);
                    var returnParameter = sComm.Parameters.Add("@Confirm", SqlDbType.Bit);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    sConn.Open();
                    //// NonQuery
                    sComm.ExecuteNonQuery();
                    var result = returnParameter.Value;
                   
                }
            }
