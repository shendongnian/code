    public class Customer {
        [Key]
        public int CustId {get;set;}
    
        //[Column("BillingId")]//not necessary if real column is same as property
        public int? BillingId {get;set;}
    
        [ForeignKey("BillingId")]
        [InverseProperty("Customer")]
        public Address BillingAddress{get;set;} //no need to be virtual
    
        //[Column("ShippingId")]
        public int? ShippingId {get;set;}
    
        [ForeignKey("ShippingId")]
        [InverseProperty("Customer")]//InverseProperty: Specifies the inverse of a navigation property that represents the other end of the same relationship.
        public Address ShippingAddress{get;set;} //no need to be virtual
    
        ...others...
    }
