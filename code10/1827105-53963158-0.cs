    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Equity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Instruments")]
        public int InstrumentId { get; set; }
        public virtual Instruments Instruments { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public int Volume { get; set; }
    
        public int StockId { set;get;}
        public virtual Stock Stock { set;get;}
    }
