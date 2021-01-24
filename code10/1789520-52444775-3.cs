    private bool _isInAction = false;
    public bool IsInAction
    {
        get { return _isInAction; };
        private set
        {
            if (_isInAction == value)
                throw new NotSupportedException();
            _isInAction = value;
        }
    }
