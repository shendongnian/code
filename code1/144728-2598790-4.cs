    interface IC
    {
        int IssueNumber { get; }
    }
    interface IWritableC : IC
    {
        int IssueNumber { get; set; }
    }
    class C : IWritableC
    {
        protected int _IssueNumber;
        
        public IssueNumber
        {
            get { return _IssueNumber; }
            set { _IssueNumber = value; }
        }
    }
        
    class A
    {
        public IWritableC myClassC;
        ...
    }
    
    class B
    {
        public IC myClassC;
        ...
    }
