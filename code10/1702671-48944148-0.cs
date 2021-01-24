    class Payer
    {
        public int Id {get; set;}  // primary key
        ... // other Payer properties
    }
    class PayerStatus
    {
        public int Id {get; set;}  // primary key
        // every PayerStatus belongs to exactly one Payer using foreign key:
        public int PayerId {get; set;}
        ... // other properties
    }
