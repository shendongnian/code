    public static class Library
    {
        public static void LogData(string FileNameAndPath)
        {
            StreamWriter sw = null;
            GetData getData = new GetData();
            var dataClasslist = new List<DataClass>
            {
                new DataClass {}
            };
            try
            {
                //System.Diagnostics.Debugger.Break();
                dataClasslist = getData.ReadData();
                //Create a file seperately                                
                using (sw = new StreamWriter(FileNameAndPath, true))
                using (var csv = new CsvWriter(sw))
                {
                    csv.Configuration.RegisterClassMap<DataClassMap>();
                    //csv.WriteHeader<DataClass>();
                    csv.Configuration.TrimHeaders = true;
                    csv.Configuration.HasHeaderRecord = false;
                    csv.WriteRecords(dataClasslist);
                    sw.Flush();
                    sw.Close();
                }
                var FileSize = new FileInfo(FileNameAndPath);
                //for each 1000 kb
                if (FileSize.Length >= 1e+6)
                {
                    //go back to the start to create a new file and column headers
                    Service1 serive1 = new Service1();
                    serive1.Execute();
                }
            }
            catch (Exception e)
            {
                var err = new StreamWriter("E:\\DataLogs\\Errors", true);
                err.WriteLine(DateTime.Now.ToString() + " LogData: " + e.Message.ToString());
                err.Flush();
                err.Close();
            }
        }
    }
