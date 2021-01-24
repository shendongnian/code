     using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();    
                    string myXml = XDocument.Load("G:\\new repo\\setting xmls\\settings.xml").ToString();                     
                    NpgsqlCommand dbcmd = conn.CreateCommand();
                    try
                    {
    
                        string sql = string.Format("SET SEARCH_PATH to Public;");                     
                        string sql0 = string.Format(@"INSERT INTO Public.""UserProfile"" (setting, userstatus, userstatusdescription, id) VALUES (@myXml, true, 'active', 'ddd');");                    
                        dbcmd.CommandText = sql + sql0;
                        NpgsqlParameter p = new NpgsqlParameter("@myXml", NpgsqlTypes.NpgsqlDbType.Xml);
                        p.Value = myXml;                   
                        dbcmd.Parameters.Add(p);
                        dbcmd.ExecuteNonQuery();
    
                    }
                    catch (Exception ex)
                    {
    
                        throw;
                    }
                    
               
    
                } 
