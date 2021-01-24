    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Client { get; set; }
        [Index]
        public DateTime Time { get; set; }
    }
