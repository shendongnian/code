    protected void ReadXML(string tableName)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("~") + "App_Data\\" + tableName + ".xml");
        using (SqlBulkCopy sbc = new SqlBulkCopy(WebConfigurationManager.ConnectionStrings["LocalSQL"].ConnectionString))
        {
            sbc.DestinationTableName = tableName;
            sbc.WriteToServer(ds.Tables[tableName]);
            sbc.Close();
        }
    }
