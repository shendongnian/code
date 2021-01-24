    public static void SetSettingFlag(string name, ParamViewModel[] array, SET s = SET.None)
    {
        foreach (var setting in array)
        {
            if (setting.Name == name)
            {
                setting.IsSelected = true;
                if(s != SET.None)
                    App.DB.UpdateIntSetting(s, setting.Id);
            }
            else
                setting.IsSelected = false;
        }
    }
