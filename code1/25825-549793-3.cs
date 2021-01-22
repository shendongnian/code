    // See (1)
    using (ComReference<StreamClass> adoStreamClass =
        LoadTextFromDBToADODBStream(resultID, "@result_id",
        "some sql statement", ref size))
    {
        // Set to the class instance.  See (2)
        StreamClass adoStream = adoStreamClass.Reference;
    
        if (adoStream.Size == 0)
        {
            success = false;
        }
        else
        {
            adoStream.Position = 0;
    
            DataTable table = new DataTable();
    
            // See (3)
            using (ComReference<RecordsetClass> rsClass = 
            ComReference<RecordsetClass>.Create())
            {
                Recordset rs = new Recordset();
                rs.Open(adoStream, Type.Missing, CursorTypeEnum.adOpenStatic,
                          LockTypeEnum.adLockBatchOptimistic, -1);
    
                if (adoStream != null)
                {
                    adoStream.Close();
                    adoStream = null;
                }
    
                source.SourceRows = rs.RecordCount;
                table.TableName = "Source";
                source.Dataset = new DataSet();
                source.Dataset.Tables.Add(table);
    
                // See (4)
                using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                {
                    adapter.MissingSchemaAction = 
                        MissingSchemaAction.AddWithKey;
                    adapter.Fill(source.Dataset.Tables[0], rs);
                }
            }
        }
    }
