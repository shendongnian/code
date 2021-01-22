    public static void ParseTSV(string filepath)
        {
            using (CsvReader csvReader = new CsvReader(new StreamReader(filepath), true, '\t')) {
                int fieldcount = csvReader.FieldCount;
                //Does not work, since it's read only property
                //csvReader.Delimiter = "\t";
                
                string[] headers = csvReader.GetFieldHeaders();
                while (csvReader.ReadNextRecord()) {
                    for (int i = 0; i < fieldcount; i++) {
                        string msg = String.Format("{0}\r{1};", headers[i],
                                                   csvReader[i]);
                        Console.Write(msg);
                    }
                    Console.WriteLine();
                }
            }
        }
