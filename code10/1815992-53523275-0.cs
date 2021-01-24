    public class Account {
       public Account(string name) {
           Name = name;
       }
       // Name is required for a valid account, so it is part of the constructor
       public string Name { get; private set; }
    
       // Balance is critical, so it is private to prevent direct manipulation from outside
       private decimal Balance { get; set; }
    
       public decimal GetCurrentBalance() {
           return Balance;
       }
    
       public void Deposit(decimal amount) {
           Balance += amount;
           // here would be a good place to write audit logs ...
       }
       public void Withdraw(decimal amount) {
           if (Balance < amount) {
               throw new InvalidOperationException($"The account '{Name}' can not be overdrawn.")
           }
           Balance -= amount;
       }
    } 
