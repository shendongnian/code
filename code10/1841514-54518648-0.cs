        private DataTable GetDataFromFirstSheet(string connection)
        {
            using (OleDbConnection conn = new OleDbConnection(connection))
            {
                using (DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" }))
                {
                    string firstSheet = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                    //try to remove $ from sheetname if it will be not working
                    using (OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{firstSheet}$]", conn))
                    {
                        using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                        {
                            conn.Open();
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            return dt;
                        }                            
                    }
                }
            }
        }
