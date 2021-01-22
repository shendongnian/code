        static void IF_EXISTS_DELETE_AND_CREATE(string cn)
        {
            //cn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =";
            //cn += AppDomain.CurrentDomain.BaseDirectory.ToString() + "test.mdb"; 
            try
            {
                OleDbConnection connection = new OleDbConnection(cn);
                object[] objArrRestrict;
                objArrRestrict = new object[] { null, null, null, "TABLE" };
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);
                connection.Close();
                string[] list;
                if(schemaTable.Rows.Count > 0)
                {
                    list = new string[schemaTable.Rows.Count];
                    int i = 0;
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        list[i++] = row["TABLE_NAME"].ToString();
                    }
                    for ( i = 0; i < list.Length; i++)
                    {
                        if(list[i] == "TEMP")
                        {
                            string deletedl = "DROP TABLE TEMP";
                            using (OleDbConnection conn = new OleDbConnection(cn))
                            {
                                using (OleDbCommand cmd = new OleDbCommand(deletedl, conn))
                                {
                                    
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }
                            break;
                        }
                    }
                }
                string ddl = "CREATE TABLE TEMP (USERID INTEGER NOT NULL,[ADATE] TEXT(20), [ATIME] TEXT(20))";
                using(OleDbConnection conn = new OleDbConnection(cn))
                {                    
                    using(OleDbCommand cmd = new OleDbCommand(ddl, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (System.Exception e)
            {
                string ex = e.Message;
            }
        }
