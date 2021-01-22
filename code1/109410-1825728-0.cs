    private List<Contract> _contracts;
    public List<Contract> Contracts
    {
        get
        {
            if (_contracts == null)
            {
                _contracts = new List<Contract>();
            }
            return _contracts;
        }
        set
        {
            if (!_contracts.Equals(value))
            {
                _contracts = value;
            }
        }
    }
