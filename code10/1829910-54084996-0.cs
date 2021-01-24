            public void Main()
            {
                ConnectionManager cm;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"e:\jsontest"))
                {
                    System.Data.SqlClient.SqlConnection sqlConn;
                    System.Data.SqlClient.SqlCommand sqlComm;
                    cm = Dts.Connections["crm_vm_2017_cs_dotnet"];
                    sqlConn = (System.Data.SqlClient.SqlConnection)cm.AcquireConnection(Dts.Transaction);
                    sqlComm = new System.Data.SqlClient.SqlCommand("select * from JJVCProduct for json auto", sqlConn);
                    System.Data.SqlClient.SqlDataReader reader = sqlComm.ExecuteReader();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    try
                    {
                        while (reader.Read())
                        {
                            file.Write(reader.GetValue(0).ToString());
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                    cm.ReleaseConnection(sqlConn);
                    Dts.TaskResult = (int)ScriptResults.Success;
                }
            }
