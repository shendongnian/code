    var dtcolumns = new string[] { "Col1", "Col2", "Col3"};
    
    var dtDistinct = dt.DefaultView.ToTable(true, dtcolumns);
    
    using (SqlConnection cn = new SqlConnection(cn) 
    {
                    copy.ColumnMappings.Add(0, 0);
                    copy.ColumnMappings.Add(1, 1);
                    copy.ColumnMappings.Add(2, 2);
                    copy.DestinationTableName = "TableNameToMapTo";
                    copy.WriteToServer(dtDistinct );
    }
