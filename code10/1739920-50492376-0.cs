    public struct StdDev
    {
        public decimal Val { get; }
        public decimal Dev { get; }
        public decimal Max { get { return Val + Dev; } }
        public decimal Min { get { return Val - Dev; } }
        public bool IsInDev (decimal val)
        {
            return val >= Min && val <= Max;
        }
        public override string ToString()
        {
            return $"{Val} +- {Dev}";
        }
        public StdDev (decimal val, decimal dev)
        {
            Val = val;
            Dev = dev;
        }
    }
