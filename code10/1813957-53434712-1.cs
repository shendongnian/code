    class CsvExemple
    {
        string inputPath = "datas.csv";
        string outputPath = "datasOut.csv";
        List<data> datas;
        public void Demo()
        {
            //no duplicate row in orginal input
            InitialiseFile();
            LoadExistingData();
            //add some new row and some dupe
            NewDatasArrived();
            //save to an other Path, to Compare. 
            SaveDatas();
        }
        private void SaveDatas()
        {
            using (TextWriter writer = new StreamWriter(outputPath))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.RegisterClassMap<dataMapping>();
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = false;
                csvWriter.WriteRecords(datas);
            }
        }
        static List<int> SuperZip(params List<int>[] sourceLists)
        {
            for (var i = 1; i < sourceLists.Length; i++)
            {
                sourceLists[0] = sourceLists[0].Zip(sourceLists[i], (a, b) => a + b).ToList();
            }
            return sourceLists[0];
        }
        private void NewDatasArrived()
        {
            var now = DateTime.Today;
            // New rows
            var outOfInitialDataRange = Enumerable.Range(11, 15)
                                .Select(x => new data { TimeStamp = now.AddDays(-x), Numbers = new List<int> { x, x, x } });
            // Duplicate rows
            var inOfInitialDataRange = Enumerable.Range(3, 7)
                                .Select(x => new data { TimeStamp = now.AddDays(-x), Numbers = new List<int> { x, x, x } });
            //add all of them them together
            datas.AddRange(outOfInitialDataRange);
            datas.AddRange(inOfInitialDataRange);
            // all this could have been one Line
            var grouped = datas.GroupBy(x => x.TimeStamp);
            var temp = grouped.Select(g => new { TimeStamp = g.Key, ManyNumbers = g.Select(x => x.Numbers).ToArray() });
            // We can combine element of 2 list using Zip. ListA.Zip(ListB, (a, b) => a + b)
            datas = temp.Select(x => new data { TimeStamp = x.TimeStamp, Numbers = SuperZip(x.ManyNumbers) }).ToList();
        }
        private void LoadExistingData()
        {
            if (File.Exists(inputPath))
            {
                using (TextReader reader = new StreamReader(inputPath))
                using (var csvReader = new CsvReader(reader))
                {
                    csvReader.Configuration.RegisterClassMap<dataMapping>();
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.Delimiter = ";";
                    datas = csvReader.GetRecords<data>().ToList();
                }
            }
            else
            {
                datas = new List<data>();
            }
        }
        private void InitialiseFile()
        {
            if (File.Exists(inputPath))
            {
                return;
            }
            var now = DateTime.Today;
            var ExistingData = Enumerable.Range(0, 10)
                                .Select(x => new data { TimeStamp = now.AddDays(-x), Numbers = new List<int> { x, x, x } });
            using (TextWriter writer = new StreamWriter(inputPath))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.RegisterClassMap<dataMapping>();
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = false;
                csvWriter.WriteRecords(ExistingData);
            }
        }
    }
