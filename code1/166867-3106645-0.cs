    IEnumerable<IGrouping<bool, Control>> visibleGroups = 
      from kvp in controlVisibleDictionary
      let c = this.FindControl(kvp.Key)
      where c != null
      group c by kvp.Value;
    
    foreach(IGrouping<bool, Control> g in visibleGroups)
    {
      foreach(Control c in g)
      {
        c.Visible = g.Key;
      }
    }
