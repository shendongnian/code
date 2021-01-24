    List<DataColumn> ldc_recover = new List<DataColumn>(); 
    foreach (DataColumn dataColumn in dataTable1.Columns)
    {
	    if (dataColumn.ColumnMapping == MappingType.Hidden)
	    {
		    dataColumn.ColumnMapping = MappingType.Element;
            ldc_recover.Add(dataColumn);
        }
    }
    
    // Fill the datagridview with data from datatable
    dataGridView1.DataSource = dataTable1;
    // Restore the previous columnmapping-property
    foreach (DataColumn dc_enum in ldc_recover)
    {
	    dc_enum.ColumnMapping = MappingType.Hidden;
    }
