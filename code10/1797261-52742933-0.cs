    public static void SetSettingFlag(string name, ParamViewModel[] array)
    {
        foreach (var setting in array)
        {
            setting.IsSelected = setting.Name == name;
        }
    }
    
    public static void SetSettingFlagAndUpdate(string name, ParamViewModel[] array, SET s)
    {
        foreach (var setting in array)
        {
            setting.IsSelected = setting.Name == name;
    
             if (setting.IsSelected)
             {
                App.DB.UpdateIntSetting(s, setting.Id);
             }
        }
    }
    
    public enum SET
    {
        ABtn = 0,
        BBtn = 1,
        CBtn = 2
    }
