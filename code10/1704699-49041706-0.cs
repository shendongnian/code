    public partial class Transaction
    {
        public int Id { get; set; } // Key by convention
    
        public int FromAccountID { get; set; }
        public virtual Account FromAccount { get; set; }
    
        public int? ToAccountId { get; set; }
        public virtual Account ToAccount { get; set; }
    
        public int PayeeId { get; set; }
        public virtual Payee Payee { get; set; }
        public decimal TransAmount { get; set; }
        public decimal ToTransAmount { get; set; }
    }
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }
    
        public int AccountId { get; set; }  // Key by convention
    
        [Required]
        [StringLength(150)]
        public string AccountName { get; set; }
    
        [InverseProperty("FromAccount")]
        public virtual ICollection<Transaction> TransactionsFrom { get; set; }
        [InverseProperty("ToAccount")]
        public virtual ICollection<Transaction> TransactionsTo { get; set; }
    }
