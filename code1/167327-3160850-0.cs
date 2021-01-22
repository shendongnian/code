    public MyConfig Config
    {
        get
        {
            MyConfig _config = Application["MyConfig"] as MyConfig;
            if (_config = null)
            {
                _config = new MyConfig(...);
                Application["MyConfig"] = _config;
            }
            return _config;
        }
    }
