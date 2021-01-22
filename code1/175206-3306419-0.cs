    using System.IO;
    using LumenWorks.Framework.IO.Csv;
    
    void ReadCsv()
    {
        // open the file "data.csv" which is a CSV file with headers
        using (CsvReader csv =
               new CsvReader(new StreamReader("data.csv"), true))
        {
            int fieldCount = csv.FieldCount;
            string[] headers = csv.GetFieldHeaders();
    
            while (csv.ReadNextRecord())
            {
                for (int i = 0; i < fieldCount; i++)
                    Console.Write(string.Format("{0} = {1};",
                                  headers[i], csv[i]));
    
                Console.WriteLine();
            }
        }
    }
