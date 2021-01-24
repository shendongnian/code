         private void Uloz()
            {
                using(SqlConnection myConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\zldb.mdf"";Integrated Security=True")){
                    myConnection.Open();
                    string sqlquery = @"insert into checklist (tb_00,tb_01) 
    VALUES (@tb_00, @tb_01);";
                    SqlCommand cmd = new SqlCommand(sqlquery , myConnection);    
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@podpis_mech", GlobalZL.podpis_mech);
    //edit
    //Pass parameters with explicit DB types
                        cmd.Parameters.Add(new SqlParameter("@tb_00", SqlDbType.NChar, 10) {Value = tb_00.Text});
                        cmd.Parameters.Add(new SqlParameter("@tb_01", SqlDbType.NChar, 10) {Value = tb_01.Text});
                        cmd.ExecuteNonQuery();
                }
            }
