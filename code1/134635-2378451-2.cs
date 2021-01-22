    public class Transaction
    {
        public string Name { get; set; }
        public string State { get; set; }
        protected string prefix = "Primary";
        // Declared as virtual ratther than abstract to avoid having to implement "TransactionBase"
        protected virtual void Initialise()
        { }
        public Transaction()
        {
            Initialise();
        }
        public virtual string Show()
        {
            return String.Format("{0}: {1}, {2}", prefix, Name, State);
        }
    }
    public class SecondaryTransaction : Transaction
    { 
        protected override void Initialise()
        {
            prefix = "Secondary";
        }
        public override string Show()
        {
            return String.Format("{0}: {1}, {2}", prefix, Name, State);
        }
    }
