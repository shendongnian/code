    public class MealPeriod
    {
        // A polymorphic array of "mixed" types.
        // See https://stackoverflow.com/questions/2567414/correct-xml-serialization-and-deserialization-of-mixed-types-in-net
        // and the solution by Stefan, https://stackoverflow.com/users/307747/stefan
        // for why this works.
        [XmlElement("Interval", typeof(Interval))]
        [XmlElement("Totals", typeof(Totals))]
        [XmlText(typeof(string))]
        public List<object> Items { get; set; }
    }
    public class Interval
    {
        public string Name { get; set; }
        public int Checks { get; set; }
        public int Guests { get; set; }
        public string AvgCheck { get; set; }
        public string AvgGuest { get; set; }
        public string Sales { get; set; }
    }
    public class Totals
    {
        public int Checks { get; set; }
        public int Guests { get; set; }
        public string AvgCheck { get; set; }
        public string AvgGuest { get; set; }
        public string Sales { get; set; }
    }
