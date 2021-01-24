        private static long _lastPos = 0;//Store this in a file and load on Apllication start
        private static int _lastProcessed = -1;//Store this in a file and load on Apllication start
        private static int _bufferSize = 4096;
        private static bool _break = true; //Set or reset in btpause_click
        static void Main(string[] args)
        {
            Loop();
            Loop();
            Loop();
            
        }
        private static void Loop()
        {
            int customerID = 0;
            string inputFilePath = "D:\\temp\\customerids.csv";
            using (StreamReader input = new StreamReader(inputFilePath, Encoding.UTF8, true, _bufferSize))
            {
                if (_lastPos > 0) input.BaseStream.Position = _lastPos;
                using (CsvReader csvread = new CsvReader(input, new Configuration(){Delimiter = "\t"}))
                {
                    IEnumerable<dynamic> records = csvread.GetRecords<dynamic>();
                    //StringBuilder buildtext = new StringBuilder();
                    foreach (var record in records)
                    {
                        //process customerID
                        var cosId = Int32.Parse(record.CustomerID);
                        if (_lastProcessed >= cosId) continue; //Skip to next if lower than processed
                        _lastProcessed = cosId;
                        
                        _lastPos = input.BaseStream.Position - _bufferSize;
                        Console.WriteLine(" > " + record.CustomerID + "\t" + record.Name);
                        if (_break) break;
                    }
                }
            }
        }
