    SqlParameter[] param = new {
           new SqlParameter("@stredisko",ValueHereForThisParam),
           //add rest the required params here
    }
    
    SqlConnection oCon = new SqlConnection(ConnectionString);
    SqlCommand oCom = new SqlCommand();
    oCom.Connection =  oCon;
    oCom.CommandType = CommandType.StoredProcedure;
    oCom.CommandText = "sp_InsertUpdate_InterniLozniListS3_Hlavicka";
    oCom.Parameters.AddRange(param )
    oCon.Open();
    int i = oCom.ExecuteScalar(); //Will return the added
    oCon.Close();
