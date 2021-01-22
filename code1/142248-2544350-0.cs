    List<Parameter> _to;
    public List<Parameter> To
    {
        get
        {
            if (_to != null && _to.Count == 0) return null;
            return _to;
        }
        set { _to = value; }
    }
