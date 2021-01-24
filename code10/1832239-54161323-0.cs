    using LumenWorks.Framework.IO.Csv;
    using (StreamReader sr = new StreamReader(@"c:\cdh\foo.csv"))
    {
        using (CsvReader reader = new CsvReader(sr, hasHeaders:false, delimiter:';', quote:'"'))
        {
            while (reader.ReadNextRecord())
            {
                for (int i = 0; i < maxFieldCount; i++)
                {
                    try
                    {
                        string val = reader[i];
                        // do something with 'val'
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
