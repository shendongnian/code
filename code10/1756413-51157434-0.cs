    class Program
    {
        static void Main(string[] args)
        {
            var StartingRecords = new List<Record>()
            {
                new Record(1001930, "A", "IN"),
                new Record(1004901, "B", "IN"),
                new Record(1005192, "A", "OUT"),
                new Record(1012933, "A", "IN"),
                new Record(1014495, "B", "OUT"),
                new Record(1017891, "A", "OUT"),
            };
            var records = StartingRecords.OrderBy(x => x.BadgeId).ThenBy(x => x.Time).ToList();
            var pairs = records.Skip(1).Zip(records, (second, first) => Tuple.Create(first, second)).
            Where(x => x.Item1.BadgeId == x.Item2.BadgeId &&
            x.Item1.Direction == "IN" && x.Item2.Direction == "OUT").
            Select(x => new Pair(x.Item1.BadgeId, x.Item1.Time, x.Item2.Time)).ToList();
            foreach (var pair in pairs)
                Console.WriteLine(pair.BadgeId + "\t" + pair.TimeIn + "\t" + pair.TimeOut);
            Console.Read();
        }
    }
    class Record
    {
        public long Time { get; set; }
        public string BadgeId { get; set; }
        public string Direction { get; set; }
        public Record(long time, string badgeId, string direction)
        {
            Time = time;
            BadgeId = badgeId;
            Direction = direction;
        }
    }
    class Pair
    {
        public string BadgeId { get; set; }
        public long TimeIn { get; set; }
        public long TimeOut { get; set; }
        public Pair(string badgeId, long timeIn, long timeOut)
        {
            BadgeId = badgeId;
            TimeIn = timeIn;
            TimeOut = timeOut;
        }
    }
