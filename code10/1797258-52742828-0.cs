    public static void SetSettingFlag(string name, ParamViewModel[] array, SET s = null)
    {
        foreach (var setting in array)
        {
            if (setting.Name == name)
            {
                setting.IsSelected = true;
                if(s != null)
                    App.DB.UpdateIntSetting(s, setting.Id);
            }
            else
                setting.IsSelected = false;
        }
    }
