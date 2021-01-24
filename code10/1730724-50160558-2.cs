    public class Class1
    {
        public int ID { get; set; }       
        public string Battery { get; set; }
        public string CurrentUse { get; set; }
        public string Occupancy { get; set; }
        public static List<Class1> myList = new List<Class1>()
        {
            new Class1() {ID = 1, Battery = "70", CurrentUse = "xxxx", Occupancy = "xxxx" },
            new Class1() {ID = 2, Battery = "100", CurrentUse = "xxxx", Occupancy = "xxxx" },
            new Class1() {ID = 3, Battery = "10", CurrentUse = "xxxx", Occupancy = "xxxx" },
            new Class1() {ID = 4, Battery = "50", CurrentUse = "xxxx", Occupancy = "xxxx" },
            new Class1() {ID = 5, Battery = "80", CurrentUse = "xxxx", Occupancy = "xxxx" },
            new Class1() {ID = 5, Battery = "40", CurrentUse = "xxxx", Occupancy = "xxxx" },
            new Class1() {ID = 5, Battery = "39", CurrentUse = "xxxx", Occupancy = "xxxx" }
        };
    }
