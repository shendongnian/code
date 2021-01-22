    public class ContactLoader
    {
        public List<Contact> Contacts { get; private set; }
        private readonly IRepository<Contact> contactsRepository;
        public ContactLoader(IRepository<Contact> contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }
        public event AsyncCompletedEventHandler Completed;
        public void OnCompleted(AsyncCompletedEventArgs args)
        {
            if (Completed != null)
                Completed(this, args);
        }
        public bool Cancel { get; set; }
        
        private SynchronizationContext _loadContext;
        public void LoadAsync(AsyncCompletedEventHandler completed)
        {
            Completed += completed;
            LoadAsync();
        }
        public void LoadAsync()
        {
            if (_loadContext != null)
                throw new InvalidOperationException("This component can only handle 1 async request at a time");
            _loadContext = SynchronizationContext.Current;
            ThreadPool.QueueUserWorkItem(new WaitCallback(_Load));
        }
        public void Load()
        {
            _Load(null);
        }
        private void _Load(object state)
        {
            Exception asyncException = null;
            try
            {
                Contacts = contactsRepository.GetAll();
                if (Cancel)
                {
                    _Cancel();
                    return;
                }
            }
            catch (Exception ex)
            {
                asyncException = ex;
            }
            if (_loadContext != null)
            {
                AsyncCompletedEventArgs e = new AsyncCompletedEventArgs(asyncException, false, null);
                _loadContext.Post(args =>
                {
                    OnCompleted(args as AsyncCompletedEventArgs);
                }, e);
                _loadContext = null;
            }
            else
            {
                if (asyncException != null) throw asyncException;
            }
        }
        private void _Cancel()
        {
            if (_loadContext != null)
            {
                AsyncCompletedEventArgs e = new AsyncCompletedEventArgs(null, true, null);
                _loadContext.Post(args =>
                {
                    OnCompleted(args as AsyncCompletedEventArgs);
                }, e);
                _loadContext = null;
            }
        }
    }
