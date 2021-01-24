    private iSqlProvider _sqlprovider;
    private ISettingsProvider _settingsProvider;
    MyClass(ISqlProvider sqlprovider, ISettingProvider settingProvider)
    {
    _sqlprovider = sqlprovider;
    _settingsProvider = settingsProvider
    
    }
    public MyClassModel GetMyAwesomeModels()
    {
    var settings = _setingsprovider.getSetting()
    settings.maxTries
     //do your magic with maxtries
    }
