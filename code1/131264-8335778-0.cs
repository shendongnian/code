    -- Creating index for table based on custom extensions --
    <#
       foreach (EntitySet entitySet in Store.GetAllEntitySets())
       {
         string tableName = Id(entitySet.GetTableName());
         string schemaName = Id(entitySet.GetSchemaName());
         EdmProperties props = entitySet.ElementType.Properties;
         foreach (EdmProperty ep in props.Where(p =>
                               p.TypeUsage.EdmType is PrimitiveType))
         {
            MetadataProperty meta = ep.MetadataProperties.FirstOrDefault(mp => mp.Name == "http://www.microsoft.com/userExtensions:Index");
            if (meta != null)
            {
                System.Xml.Linq.XElement e = meta.Value as System.Xml.Linq.XElement;
                System.Xml.Linq.XAttribute attr = e.Attributes().FirstOrDefault(a => a.Name == "indexName");
                string indexName = attr.Value;     
                // create an index for specified column
    #>
    CREATE INDEX [IX_<#=indexName#>]
    ON <#if (!IsSQLCE) {#>[<#=schemaName#>].<#}#>[<#=tableName#>]
    ([<#=indexName#>]);
    <#
             }
         }   
       }
    #>
