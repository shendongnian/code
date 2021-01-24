    public abstract class BaseManager
    {
        private IUnitOfWork _iUow;
        public IUnitOfWork IUOW
        {
            get
            {
                if (_iUow == null)
                {
                    _iUow = new XaPaUnitOfWork(new XaPaDataContext());
                }
                return _iUow;
            }
        }
    }
