    bool FilterByName(Event evnt)
    {
      var model = filterEventsControl.ComboBoxModels.SelectedItem?.ToString();
      return evnt.DeviceName == model;
    }
    
    bool FilterByIp(Event evnt)
    {
      var ip = filterEventsControl.ComboBoxIPs.SelectedItem?.ToString();
      return evnt.Ip == ip;
    }
    
    void ViewSource_Filter(object sender, FilterEventArgs e)
    {
    ...
      bool res = true;
      if (selectedModel)
        res = res && FilterByName();
      if (selectedIp)
        res = res && FilterByIp();
    ...
    }
