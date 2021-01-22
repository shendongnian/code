            DataTable table = new DataTable();
            // set up schema... (Columns.Add)
            using(TextReader text = File.OpenText(path))
            using(CsvReader csv = new CsvReader(text, hasHeaders)) {
                table.Load(csv);
            }
