    DbCommand insert = db.GetStoredProcCommand("Insert");
    foreach (string ID in myIDs)
    {
        db.Parameters.Clear();
        db.AddInParameter(insert, "FileName", System.Data.DbType.String, 
            ID + ".xml");
        db.ExecuteNonQuery(insert, transaction);
    }
