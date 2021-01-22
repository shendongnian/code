    class C
    {
        protected int _IssueNumber;
    
        public int GetIssueNumber()
        {
            return _IssueNumber;
        }
    }
    
    class WritableC : C
    {
        public void SetIssueNumber(int issueNumber)
        {
            _IssueNumber = issueNumber;
        }
    }
    
    class A
    {
        public WritableC myClassC;
        ...
    }
    
    class B
    {
        public C myClassC;
        ...
    }
