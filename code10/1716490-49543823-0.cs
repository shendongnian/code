    static void Main(string[] args)
    {
        List<WeekObject> weekObjs = new List<WeekObject>();
        foreach (var obj in weekObjs)
        {
            SaveTime(obj.ID, obj.weekDictionary[DateTime.Today.DayOfWeek]);
        }
    }
    class WeekObject
    {
        public int ID { get; set; }
        public Dictionary<DayOfWeek, TimeSpan?> weekDictionary { get; set; } = new Dictionary<DayOfWeek, TimeSpan?>();
        public WeekObject ()
        {
            // Initialize dictionary here if you'd like
            weekDictionary.Add(DayOfWeek.Sunday, null);
        }
    }
    public static void SaveTime(int ID, TimeSpan? timeSpan)
    {
        // Your code here
    }
