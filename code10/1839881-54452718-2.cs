    <#@ import namespace="System.Data" #>
    
    <#@ property name="hashTable" type="Varigence.Languages.Biml.Table.AstTableNode" required="False"#>
    <#@ property name="tableNorm" type="String" required="True"#>
    <#@ property name="LoadType" type="String" required="True"#>
    <#@ property name="connectionWrk" type="Varigence.Languages.Biml.Connection.AstOleDbConnectionNode" required="True" #>
    <!-- I exist -->
    <# 
    string connstring = connectionWrk.ConnectionString;
    var results = ExternalDataAccess.GetDataTable(connectionWrk,"SELECT 'This is tier 3' AS TierName;") ;
    
    foreach (System.Data.DataRow row in results.Rows)
    {
        for (int columnIndex = 0; columnIndex < results.Columns.Count; columnIndex++)
        {
            Write(string.Format("!<-- {0} -->\t", row[columnIndex]));
        }
    
        Write("\n");
    }
    #>
