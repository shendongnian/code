     public class CSVTableExportProvider<TTable, TRecord>
            where TTable : SimpleBase, new()
            where TRecord : IConvertTypeToCSVRecord<TTable>, new()
     {
        public void ExportTable(string path, string filename, bool continueOnError)
        {
          var rows = _service.GetList<TTable>();
          var records = new List<TRecord>();
          var csvfile = Path.Combine(path, filename);
         
          var csvFile = new CSVFile<TRecord>(csvfile, continueOnError);
     
            foreach (var row in rows)
            {
              var rec = new TRecord();
              rec.ConvertTypeToCSVRecord(row);
              records.Add(rec);
            }
            csvFile.ConvertRecordsToFile(records.ToArray());
         }
     }
