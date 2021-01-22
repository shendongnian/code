    private T GetProperty<T>(Func<Settings, T> GetFunc)
    {
        try
        {
            return GetFunc(Properties.Settings.Default);
        }
        catch (Exception exception)
        {
            SettingReadException(this,exception);
            return default(T);
        }
    }
