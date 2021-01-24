    public class DaysDetails
    {
        public bool Sun { get; set; }
        public bool Mon { get; set; }
        public bool Sat { get; set; }
    }
    public string ConstructDays(DaysDetails d)
    {
        var week = new[]
        {
            Convert.ToInt32(d.Sat),
            Convert.ToInt32(d.Sun),
            Convert.ToInt32(d.Mon),
        };
        return string.Join(",",  week);
    }
