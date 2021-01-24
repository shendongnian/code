    interface IArchiveFactory
    {
         IArchive Create();
    }
    class ArchiveFactory : IArchiveFactory
    {
        public IArchive Create()
        {
            return new MyDbContext(...);
        }
    }
    class TestArchiveFactory : IArchivedFactory
    {
        public IArchive TestData {get; set;}
        public IArchive Create()
        {
             return this.TestData;
        }
    }
