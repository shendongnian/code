    var listOfUserControls = GetUserControls(Page);
    ...
    public List<UserControl> GetUserControls(Control ctrl)
    {
      var uCtrls = new List<UserControl>();
      foreach (Control child in ctrl.Controls) {
        if (child is UserControl) uCtrls.Add((UserControl)child);
        uCtrls.AddRange(GetUserControls(child);
      }
      
      return uCtrls;
    }
