    public int Age
    {
        get { return _age; }
        set
        {
            var init = _age;
            //You still need to change the _age to the value
            _age = value;
            this.CheckPropertyChanged<int>("Age", ref init, ref value);
        }
    }
