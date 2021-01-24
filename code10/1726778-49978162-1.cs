    public class Device
    {
        public long Id { get; set; }
        public string Uid { get; set; }
        public Type Type { get; set; }
        public Status Status { get; set; }
        public virtual List<Ping> Pings { get; set; } //Newly added
    }
