    public BusinessObject Item
    {
        get
        {
            if (_Item == null)
                _Item = new BusinessObject();
    
            return _Item; 
        }
    }
    private BusinessObject _Item;  
