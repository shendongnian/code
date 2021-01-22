        private static DataTable LoadCsvData(string refPath)
        {
            var cfg = new Configuration() { Delimiter = ",", HasHeaderRecord = true };
            var result = new DataTable();
            using (var sr = new StreamReader(refPath, Encoding.UTF8, false, 16384 * 2))
            {
                using (var rdr = new CsvReader(sr, cfg))
                using (var dataRdr = new CsvDataReader(rdr))
                {
                    result.Load(dataRdr);
                }
            }
            return result;
        }
