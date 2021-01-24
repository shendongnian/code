    class ApplicationUser : IdentityUser
    {
        public int Id {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<TransactionModel> Transactions { get; set; }
    }
