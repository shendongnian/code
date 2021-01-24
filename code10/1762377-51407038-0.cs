    public class ReceivedGoods
    {
        ...
        public int ReceivingId { get; set; }
        ...
        public virtual ReceivedGoodsProperties properties { get; set; }
    }
    
    public class ReceivedGoodsProperties
    {
        ...
        public int Id { get; set; } // This is PK
        [ForeignKey( "goods " )]
        public int ReceivingId { get; set; } // This is FK
        ...
        [Required]
        public virtual ReceivedGoods goods { get; set; }
    }
