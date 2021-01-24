    public class DataPointGridViewModel 
    {
        public int DataPointId { get; set; }
        public string Description { get; set; }
        public bool InAlarm { get; set; }
        public DateTime LastUpdate { get; set; }
        public double ScalingMultiplier { get; set; }
        public decimal Price { get; set; }
    }
