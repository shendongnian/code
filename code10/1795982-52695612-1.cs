    var setting = vm.PTI.FirstOrDefault( s => s.Name == name );
    if (setting != null)
    {
        setting.IsSelected = true;
        App.DBUpdateIntSetting(SET.Pti, setting.Id);
    }
