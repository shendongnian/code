    class Timeslot
    {
        public DateTime InputTime { get; set; }
        public DateTime OutputTime { get; set; }
    }
    public static void Main()
    {
        var timeList = new List<Timeslot>(); 
        //populate the list
        var sortedList = timeList.OrderBy(t => t.InputTime).ToList();
    }
