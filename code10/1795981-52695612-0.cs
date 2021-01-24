    var setting = vm.PTI.Where( s => s.Name == name ).FirstOrDefault();
    if (setting != null)
    {
        setting.IsSelected = true;
        App.DBUpdateIntSetting(SET.Pti, setting.Id);
    }
