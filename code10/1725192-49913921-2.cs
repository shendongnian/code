    public class Account
    {
        //other properties...
        [ConcurrencyCheck]
        public decimal Balance {get; set;}
    }
    
