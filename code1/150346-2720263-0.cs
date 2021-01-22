    [FixedLengthRecord]
    public class PriceRecord
    {
        [FieldFixedLength(6)]
        public int ProductId;
    
        [FieldFixedLength(8)]
        [FieldConverter(typeof(MoneyConverter))]
        public decimal PriceList;
    
        [FieldFixedLength(8)]
        [FieldConverter(typeof(MoneyConverter))]
        public decimal PriceOnePay;
    }
