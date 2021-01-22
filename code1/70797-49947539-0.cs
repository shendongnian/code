    private string _Id = system.Guid.NewGuid().ToString();
    private bool _IdSet = false;
    public string Id {
        get { return _Id; }
        set 
        { 
            if(!_IdSet)
            {
                _Id = value;
                _IdSet = true;
            }
            // else throw exception?
        }
    }
