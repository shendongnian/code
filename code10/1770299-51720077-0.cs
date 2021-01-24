     [Table("@FORECAST")]
        public class FORECAST : BindableBase
        {
    
            private int _code;        
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Browsable(false)]        
            public int Code
            {
                get { return this._code; }
                set { SetProperty(ref _code, value); }
            }
    
            private string _Name;
            [Browsable(false)]
            public string Name
            {
                get { return this._Name; }
                set { SetProperty(ref _Name, value); }
            }
    
            private int _DocEntry;
            public int DocEntry
            {
                get { return this._DocEntry; }
                set { SetProperty(ref _DocEntry, value); }
            }
    
            private int _PeriodID;
            public int PeriodID
            {
                get { return this._PeriodID; }
                set { SetProperty(ref _PeriodID, value); }
            }
    
            private int _SkuLineNum;
            public int SkuLineNum
            {
                get { return this._SkuLineNum; }
                set { SetProperty(ref _SkuLineNum, value); }
            }
    
            private int _CustLineNum;
            public int CustLineNum
            {
                get { return this._CustLineNum; }
                set { SetProperty(ref _CustLineNum, value); }
            }
    
            private decimal _Value;
            [DisplayName("Forecast value")]
            public decimal Value
            {
                get { return this._Value; }
                set { SetProperty(ref _Value, value); }
            }
    
            private CUST _FTTCust;
            public virtual CUST FTTCust
            {
                get { return this._FTTCust; }
                set { SetProperty(ref _FTTCust, value); }
            }
    
            private Period _FTTPeriod;
            public virtual Period FTTPeriod
            {
                get { return this._FTTPeriod; }
                set { SetProperty(ref _FTTPeriod, value); }
            }
    
            private SKU _FTTSku;
            public virtual SKU FTTSku
            {
                get { return this._FTTSku; }
                set { SetProperty(ref _FTTSku, value); }
            }
        }
    [Table("@SKU")]
        public partial class SKU
        {
           
            [Browsable(false)]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
            public int Code { get; set; }
    
            [Browsable(false)]      
            public int DocEntry { get; set; }
    
            [StringLength(15)]
            [DisplayName("Item Code")]
            public string ItemCode { get; set; }
                   
            [StringLength(100)]
            [DisplayName("Item Name")]
            public string Name { get; set; }
            
            [StringLength(15)]
            [DisplayName("H Level 0")]
            public string Level0 { get; set; }
    
            [StringLength(15)]
            [DisplayName("H Level 1")]
            public string Level1 { get; set; }
            
        }
