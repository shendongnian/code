    public class Transaction
    {
        public string Name { get; set; }
        public string State { get; set; }
        protected string prefix = "Primary";
        public virtual string Show()
        {
            return String.Format("{0}: {1}, {2}", prefix, Name, State);
        }
    }
    public class SecondaryTransaction : Transaction
    { 
        public SecondaryTransaction()
        {
            prefix = "Secondary";
        }
        public override string Show()
        {
            return String.Format("{0}: {1}, {2}", prefix, Name, State);
        }
    }
