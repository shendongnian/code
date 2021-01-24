    if (user != null)
        {
            if (user.type != null && user.user != null && user.pass != null)
            {
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT ID,UserName From Partner ";
                //Where UserName=@UserName And PassWord=@Pass
                //cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = user.user;
                //  cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 100).Value = user.pass;
                if (ConnectionState.Closed == con.State)
                    con.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                con.Close();
                sqlDataAdapter.Fill(datatable);
                int i = 0;
                if (datatable.Rows.Count > 0)
                {
                    foreach (DataRow dr in datatable.Rows)
                    {
                        json += "A" + i + ":{ID:'" + dr["ID"] + "',User:'" + dr["UserName"] + "'},";
                        i++;
                    }
                    json = json.Remove(json.Length - 1);
                    json += "}";
                    JObject json2 = JObject.Parse(json);
                    context.Response.Write(json2);
                    return;
                }
                else
                    json = "{'result':'false'}";
            }
            else
                json = "{'result':'false'}";
            JObject json3 = JObject.Parse(json);
            context.Response.Write(json3);
            return;
        }
