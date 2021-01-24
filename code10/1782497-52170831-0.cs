    public class TransactionViewModel
    {
        public string type { get; set; }
        public string operationType { get; set; }
        public string operationState { get; set; }
        public DateTime created { get; set; }
        public Transaction transaction { get; set; } // child object
    }
