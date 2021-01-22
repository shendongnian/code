    var linqCSV = new CsvToXml("csvfile", true);
    linqCsv.TextQualifier = null;
    
    linqCsv.ColumnTypes.Add("Plant", typeof(string));
    linqCsv.ColumnTypes.Add("Material", typeof(int));
    linqCsv.ColumnTypes.Add("DensityLbft3", typeof(double));
    linqCsv.ColumnTypes.Add("StorageLocation", typeof(int));
    
    linqCsv.Convert();
    
