    private List<Models.AreasOfLaw> aolTitles = new List<Models.AreasOfLaw>();
    public List<Models.AreasOfLaw> AreasOfLawListItems
    {
        get { return aolTitles; }
        set { aolTitles = value; OnPropertyChanged("AoLTitles"); }
    }
