    private void SetRessource(ref Ressource res, string value)
    {
        if(res == null) res = new Ressource();
    
        res.DefaultValue = value;
    }
    public String TravelName
    {
        get { return LocaleHelper.GetRessource(Ressource1); }
        set { SetRessource(ref this.Ressource1, value); }
    }
    public String TravelDescription
    {
        get { return LocaleHelper.GetRessource(Ressource2); }
        set { SetRessource(ref this.Ressource2, value); }
    }
