    public ObservableCollection<Recipient> Recipients
    {
        get
        {
            if (_recipients == null)
            {
                // DO NOT create collection inside constructor
                _recipients = new ObservableCollection<Recipient>();          
            }
            return _recipients;
        }
    }
