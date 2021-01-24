    [DbFunction("CodeFirstDatabaseSchema", "fn_IsCorrectProduct")]
    public bool Fn_IsCorrectProduct(string companyID, string itemCode)
    {
        // UDF is described in DbFunction attribute; no need to provide an implementation...
        throw new NotSupportedException();
    }
