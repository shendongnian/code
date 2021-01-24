    string _dbData;
    public string DBData
    {
        get
        {
            if(_dbData == null)
                return null;
            else
                return _dbData;
        }
        private set
        {
            _dbData= value;
        }
    }
