    private List<Machine> _machines;
    public List<Machine> Machines
    {
        get
        { 
            //Get Machines by Stage ID and put them on List<Machine>
            //only if we have not already done so
            if (_machines == null)
            {
                _machines = Machine.Get(this.ID);
            }
            
            return _machines; 
        }
        set{ _machines = value; }
    }
