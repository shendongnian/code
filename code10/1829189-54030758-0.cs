    [Display(Name="Trade Spend Type")]
    [Column("TradeSpendID")]
    [ForeignKey("PromotionTradeSpendType")]
    public int? TradeSpendId { get; set; }
    public virtual PromotionTradeSpendType PromotionTradeSpendType { get; set; }
    
    [Display(Name = "Trade Spend Sub Type")]
    [Column("TradeSpendSubID")]
    [ForeignKey("PromotionTradeSpendSubType")]
    public int? TradeSpendSubId { get; set; }
    public virtual PromotionTradeSpendType PromotionTradeSpendSubType { get; set; }
