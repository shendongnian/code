    <#@ import namespace="System.Data" #> 
    
    <#@ property name="table" type="Varigence.Languages.Biml.Table.AstTableNode" #>
    <#@ property name="columnList" type="String" #>
    <#@ property name="tableNorm" type="String" #>
    <#@ property name="connectionWrk" type="Varigence.Languages.Biml.Connection.AstOleDbConnectionNode" #>
    <!-- Tier 2 debug -->
    <# string child = "so_54450877.tier3.biml" ;
    var results = ExternalDataAccess.GetDataTable(connectionWrk,"SELECT 'This is tier 2' AS TierName;") ;
    foreach (System.Data.DataRow row in results.Rows)
    {
        for (int columnIndex = 0; columnIndex < results.Columns.Count; columnIndex++)
        {
            Write(string.Format("<!-- {0} -->\t", row[columnIndex]));
        }
    
        Write("\n");
    }
       
    #>
    <#=CallBimlScript(child, columnList, tableNorm, connectionWrk, table) #>
    <!-- Tier 2 end debug -->
