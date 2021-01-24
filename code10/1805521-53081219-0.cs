    private string _name;
    public string Name
    {
    get
    {
    return String.Format("Hello, this is {0}", _name);
    }
    set
    {
    _name = value;
    RaisePropertyChanged("Name"); //bear in mind this is depended on MVVM framework you are using
    }
    }
