    using (SqlConnection myCon = DBCon)
    {
        try
        {
           string Qry =  @"SELECT [OPSProcedure],[OPSInsertedOn],[OPSInsertedBy]
                           FROM [Operation] where OPSID =  @id;
                           SELECT  LKCPID  FROM dbo.ConcurrentProcedure  
                           where CPOperationID = @id;
                           SELECT IOperaitonID FROM dbo.LkupIntraOperativeAdverseEvents   
                           where IOperaitonID = @id";
            myCon.Open();
            SqlDataAdapter da = new SqlDataAdapter(Qry, myCon);
            da.SelectCommand.Parameter.Add("@id", SqlDbType.NVarChar).Value = opID;
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            // Test...
            Console.WriteLine(ds.Tables[0].Rows.Count);
            Console.WriteLine(ds.Tables[1].Rows.Count);
            Console.WriteLine(ds.Tables[2].Rows.Count);
