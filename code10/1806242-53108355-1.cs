    var mydata = dataGrouping.Select(d =>
            {
                var datadictionary = new ExportDataDictionary();
                datadictionary.ColumnData.Add("NAME", d.Key.Name);
                datadictionary.ColumnData.Add("AGE", d.Key.Age);
                
                return datadictionary;
            }).ToList();
