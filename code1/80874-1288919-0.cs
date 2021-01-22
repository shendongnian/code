       protected bool LoadXml(SqlConnection cn, XmlDocument doc)
       {
        //Reading the xml from the database
        string sql =  @"SELECT Id, XmlField  FROM TABLE_WITH_XML_FIELD WHERE Id = @Id";
        SqlCommand cm = new SqlCommand(sql, cn);
        cm.Parameters.Add(new SqlParameter("@Id",1));
        using (SqlDataReader dr = cm.ExecuteReader())
        {
                 if (dr.Read())
                {
                          SqlXml MyXml= dr.GetSqlXml(dr.GetOrdinal("XmlField"));
                          doc.LoadXml( MyXml.Value);
                          return true;
                }
                else
                {
                          return false;
                }
         }
        }
