    `class Program
        {
            static void Main(string[] args)
            {
    
                Transaction aTrans = new Transaction();
                List<Transaction> transList = new List<Transaction>();
                transList.Add(aTrans.getProduct());
            }
        }
        class Transaction
        {
           public string name { get; set; }
            public Transaction()
            {
                name = "name";
            }
            public Transaction getProduct()
            {
                return this;
            }
            
        }`
