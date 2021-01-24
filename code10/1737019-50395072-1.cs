    public struct AccountInfo : IAccountInformation
    {
        public long TotalQuota { get; set; }
        public long UsedQuota { get; set; }
        public IEnumerable<IStorageMetrics> Metrics { get; set; }
    }
