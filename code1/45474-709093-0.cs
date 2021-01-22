    var reader = SqlHelper.ExecuteReader(connectionString,
        "UpdateProduct", product.Name, product.Price, product.StockQuantity);    
    if (reader.RecordsAffected > 0)
    {
        RefreshEntity(reader, product);
        result = reader.RecordsAffected;
    }
    else
    {
        //must always close the connection
        reader.Close();
    
        // Concurrency exception
        DBConcurrencyException conflict = 
           new DBConcurrencyException("Concurrency exception");
        conflict.ModifiedRecord = product;
    
        AssessmentCollection dsrecord;
        // Get record from Datasource
        if (transactionManager != null)
            dsrecord = ProductRepository.Current.GetByName(
            this.transactionManager, product.Name);
        else
            dsrecord = ProductRepository.Current.GetByName(connectionString, 
                product.Name);
        if (dsrecord.Count > 0)
            conflict.DatasourceRecord = dsrecord[0];
    
        throw conflict;
    }
