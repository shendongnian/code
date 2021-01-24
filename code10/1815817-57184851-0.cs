    internal class CloudTableMock : CloudTable
    {
        public CloudTableMock() : base(new Uri("http://localhost"))
        {
        }
    }
