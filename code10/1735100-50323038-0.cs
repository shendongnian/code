    public class LOG
    {
        [Key]
        public int id { get; set; }
        public string statusLog { get; set; }
        public int? BarId{ get; set; }
        public virtual BAR bar { get; set; }
    }
