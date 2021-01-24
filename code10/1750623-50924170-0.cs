    using (var cloneProductCmd = new OracleCommand("SPF_SQL.CLONE_PRODUCT", con))
    {
        cloneProductCmd.BindByName = true;
        cloneProductCmd.CommandType = System.Data.CommandType.StoredProcedure;
        cloneProductCmd.Parameters.Add("P_F_CLONED_PROD_ID", product.OriginalProductId);
        cloneProductCmd.Parameters.Add("P_F_NAME", productName);
        cloneProductCmd.Parameters.Add("P_F_DESC", fullProduct.ProductName);
        cloneProductCmd.Parameters.Add("P_F_SYS_ISSUE", fullProduct.SystemIssueNumber);
   
        var featureNames = cloneProductCmd.Parameters.Add("P_F_FEATURE_NAMES", OracleDbType.Varchar2);
        featureNames.Direction = System.Data.ParameterDirection.Input;
        featureNames.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        featureNames.Value = features.Select(_ => _.Key).ToArray();
        featureNames.Size = features.Count();
        featureNames.ArrayBindSize = features.Select(_ => _.Key.Length).ToArray();
        featureNames.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, features.Count()).ToArray();
   
        var featureValues = cloneProductCmd.Parameters.Add("P_F_FEATURE_VALUES", OracleDbType.Varchar2);
        featureValues.Direction = System.Data.ParameterDirection.Input;
        featureValues.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        featureValues.Value = features.Select(_ => _.Value).ToArray();
        featureValues.Size = features.Count();
        featureValues.ArrayBindSize = features.Select(_ => _.Value.Length).ToArray();
        featureValues.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, features.Count()).ToArray();
   
        cloneProductCmd.Parameters.Add("P_F_AUDIT_USER", HttpContext.Current.User.Identity.Name);
        cloneProductCmd.Parameters.Add("P_F_PRODUCT_ID", OracleDbType.Decimal, System.Data.ParameterDirection.Output);
        var reader = await cloneProductCmd.ExecuteNonQueryAsync();
        newProductId = Convert.ToInt32(cloneProductCmd.Parameters["P_F_PRODUCT_ID"].Value.ToString());
    }
