    public class CurrentAlertStatus
    {
        public string message_type { get; set; }
        public string seconds { get; set; }
        public string deviceid { get; set; }
        public string vin { get; set; }
        public string esn { get; set; }
        public string iccid { get; set; }
}
.....
    public void ReadCsvIntoListOfObjects{
            var statuses = new List<CurrentAlertStatus>();
            var lines = File.ReadAllLines("path.csv").Skip(1);
            foreach (var line in lines)
            {
                var values = line.Split(";");
                var st = new CurrentAlertStatus();
                var props = typeof(CurrentAlertStatus).GetProperties();
                for (int i = 0; i < values.Length-1; i++)
                {
                    props[i].SetValue(st, values[i]);
                }
                statuses.Add(st);
            }
