    public class Factory : IDisposable
    {
        [Import(typeof(IRepository))]
        private Repository _repository = null;
        public Factory()
        {
            MEFImporter.DoImport(this, MEFImporter.Parameter("hello"));
        }
        public IRepository Repository
        {
            get
            {
                return _repository;
            }
        }
        public void Dispose()
        {
            _repository = null;
        }
    }
