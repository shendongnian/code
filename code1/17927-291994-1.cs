    public class Serial
    {
        public string SerialNumber {get; set;}
        public string ItemNumber {get; set;}
        public string OrderNumber {get; set;}
    }
...
    Serial serial = sessionX.get(typeof(Serial), someID);
    sessionY.save(serial);
