    private Dictionary<string, ModulesModel> modules;
    public Dictionary<string, ModulesModel> Modules
    {
        get => modules;
        set
        {
            if (!AreEqual(modules, value))
            {
                modules = value;
                OnPropertyChanged();
            }
        }
    }
