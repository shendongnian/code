    public Class1 : IDbOperation<string>
    {
        public Class1(int param1, double param2)
        {
            ...
        }
        public string Result { get; private set; }
        public void Execute(IDbConnection connection)
        {
            ...
            Result = ...;
        }
    }
    public Class2 : IDbOperation<int>
    {
        public Class2(Person person)
        {
            ...
        }
        public int Result { get; private set; }
        public void Execute(IDbConnection connection)
        {
            ...
            Result = ...;
        }
    }
