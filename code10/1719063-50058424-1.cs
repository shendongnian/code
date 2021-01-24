     [WebMethod]
            public  List<string> GetRequesters(string prefixText,int contextKey)
            {
               
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DataStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select RQID,RQ_Code, Name,Email,Phone,location from tbl_Requester where Name like @SearchText + '%'", con);
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<string> patients = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat(dt.Rows[i]["Name"].ToString() + "," + dt.Rows[i]["location"].ToString() + "," + dt.Rows[i]["Email"].ToString() + "," + dt.Rows[i]["RQID"].ToString() + " ");
                        patients.Add(sb.ToString());
                    }
                    return patients;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    GC.Collect();
                }
