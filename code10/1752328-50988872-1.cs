        //data from access
        private void insertValues(DataTable table)
        {
            using (SqlConnection con = new SqlConnection("MyConnectionStr "))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    createTable();
                    //note changed the insert to tmp table.
                    cmd.CommandText = "INSERT INTO UMP_TMP VALUES (@p1, @p2, @p3)";
                    cmd.Connection = con;
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar, 50);
                    cmd.Parameters.Add("@p2", SqlDbType.NVarChar, 50);
                    cmd.Parameters.Add("@p3", SqlDbType.NVarChar, 50);
                    con.Open();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        cmd.Parameters["@p1"].Value = table.Rows[i][0];
                        cmd.Parameters["@p2"].Value = table.Rows[i][1];
                        cmd.Parameters["@p3"].Value = table.Rows[i][2];
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                        
                            break;
                        }
                    }
                    //merge the data from within sql server
                    mergeTable();
                    //drop the temporary table
                    dropTable();
                }
            }
        }
            
		
        private void createTable(){
            issueStatement("create table UMP_TMP(p1 varchar(50), p2 varchar(50), p3 varchar(50));");
        }
        private void dropTable()
        {
            issueStatement("drop table UMP_TMP;");
        }
        private void mergeTable()
        {
            issueStatement("insert into UMP select ump_tmp.p1,ump_tmp.p2,ump_tmp.p3 from UMP_TMP left join UMP on UMP_TMP.p1 = UMP.P1 and UMP_TMP.p2 = UMP.P2 and UMP_TMP.p3 = UMP.P3 WHERE ump.p1 is null and ump.p2 is null and ump.p3 is null");
        }
        private void issueStatement(string command)
        {
            using (SqlConnection con = new SqlConnection("MyConnectionStr "))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = command;
                    //add error handling
                    cmd.ExecuteNonQuery();
                }
            }
        }
