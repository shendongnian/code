    class Customer
    {
        public int Id {get; set;}            // primary key
        ... // other properties
        // every Customer has exactly one Billing, using foreign key:
        public int RespId {get; set;}        // wouldn't BillingId be a better Name?
    }
    class Billing
    {
        public int Id {get; set;}            // primary key
        ... // other properties
    }
