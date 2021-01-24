    private static List<Data> _lstData = new List<Data>();
        private static List<int> _answerIdList;
        static void Main(string[] args)
        {
            PopulateData();
            ProcessData();
        }
        private static void PopulateData()
        {
            _lstData.Add(new Data(1, "Dong", 1, null, true));
            _lstData.Add(new Data(2, "Tay", 1, null, false));
            _lstData.Add(new Data(3, "Nam", 1, null, false));
            _lstData.Add(new Data(4, "Bac", 1, null, false));
            _lstData.Add(new Data(11, "AAA", 4, null, false));
            _lstData.Add(new Data(12, "BBB", 4, null, false));
            _lstData.Add(new Data(13, "CCC", 4, null, true));
            _lstData.Add(new Data(14, "DDD", 4, null, false));
            _lstData.Add(new Data(96, "AAA", null, 1, false));
            _lstData.Add(new Data(97, "BBB", null, 1, true));    
            _lstData.Add(new Data(98, "CCC", null, 1, false));
            _lstData.Add(new Data(99, "DDD", null, 1, false));
            _lstData.Add(new Data(102, "sdasd", 24, null, true));
            _lstData.Add(new Data(103, "sadas", 24, null, false));
            _lstData.Add(new Data(104, "dasd", 24, null, false));
            _lstData.Add(new Data(105, "sadasddsds", 24, null, false));   
            
            _answerIdList = new List<int>(new int[] { 1, 2, 3, 13, 102 });
        }
        private static void ProcessData()
        {
            var processedDataCount = _lstData.Where(x => _answerIdList.Contains(x.AnswerId) && x.IsCorrected == true).Count();
            Console.WriteLine(processedDataCount);
        }
