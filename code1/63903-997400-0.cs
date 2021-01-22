        public class ParseData
        {
            public int Offset { get; set; } 
        }
        public ObservableCollection<ParseData> OffsetList { get; set; }
        public Program()
        {
            OffsetList = new ObservableCollection<ParseData> { new ParseData { Offset = 5 } };
            int offset = 5;
            int found = OffsetList.Where(o => o.Offset.Equals(offset)).ToList().Count;
            Console.WriteLine("Found: " + found);
        }
