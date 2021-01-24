    class ClientWithLoan : Client
    {
        protected Loan _loan;
        public Loan Loan 
        { 
            get { return _loan; }
            set
            {
                if (value.ClientID != this.ID) throw ArgumentException();
                _loan = value;
            }
        }
    }
