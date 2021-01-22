        int? ReadTerminalID()
        {
            int? terminalID = null;
            
            using (FbConnection conn = connManager.CreateFbConnection())
            {
                conn.Open();
                FbCommand fbCommand = conn.CreateCommand();
                fbCommand.CommandText = "SPSYNCGETIDTERMINAL";
                fbCommand.CommandType = CommandType.StoredProcedure;
                object result = fbCommand.ExecuteScalar(); // ExecuteScalar fails on null
                if (result.GetType() != typeof(DBNull))
                {
                    terminalID = (int?)result;
                }
            }
            return terminalID;
        }
