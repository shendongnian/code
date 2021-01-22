    public class Currency
    {
        [Property]
        public virtual Int64 Amount { get; set; }   
        [Property]
        public virtual CurrencyType CurrencyType { get; set; }
    }
    
    [ActiveRecord("[Transaction]")]
    public class Transaction: HasOwnerModelBase
    {
        [BelongsTo]
        public virtual Category Category { get; set; }
        [Nested]  
        public virtual Currency Amount { get; set; }
    }
