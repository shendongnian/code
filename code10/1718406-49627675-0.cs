    public class Person {
        public long Id { get; set; }
    
        public string Name { get; set; }
    
        public DateTime? LastTransactionTimestamp { get; set; }
    }
    
    public class Transaction {
    
         public long Id { get; set; }
    
         public long PersonId { get; set; }
    
         public DateTime Timestamp { get; set; }
         public void Commit() {
             Timestamp = DateTime.Now;
         }
    }
