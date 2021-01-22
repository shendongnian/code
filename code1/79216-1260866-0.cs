    public static class SyncStatus
    {
        public const int Unavailable = 0;
        public const int Checking = 5;
        public const int StartedAspNetDb = 10;
        public const int FinishedAspNetDb = 20;
        public const int StartedMatrixDb = 30;
        public const int FinishedMatrixDb = 40;
        public const int StartedConnectDb = 50;
        public const int FinishedConnectDb = 60;
        public const int StartedCmoDb = 70;
        public const int FinishedCmoDb = 80;
        public const int StartedMcpDb = 90;
        public const int FinishedMcpDb = 100;
    }
