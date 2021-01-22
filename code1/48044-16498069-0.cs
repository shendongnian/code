    private void OnContextMenuOpening(object sender, CancelEventArgs e)
    {
      var lGrid = mCurrentControl as PropertyGrid;
      if (lGrid != null)
      {
        var lItem = lGrid.SelectedGridItem;
        // Für untergeordnete Eigenschaften kann nicht SelectedObject verwendet werden
        // Component ist eine interne Eigenschaft der Klasse System.Windows.Forms.PropertyGridInternal.GridEntry
        // ((System.Windows.Forms.PropertyGridInternal.GridEntry)(lItem)).Component
        // Zugriff via Reflection
        var lComponent = lItem.GetType().GetProperty("Component").GetValue(lItem, null);
        if (lComponent != null)
          tsmi_Reset.Enabled = lItem.PropertyDescriptor.CanResetValue(lComponent);
        else
          tsmi_Reset.Enabled = lItem.PropertyDescriptor.CanResetValue(lGrid.SelectedObject);
      }
    }
    // Contextmenu -> Reset
    private void OnResetProperty(object sender, EventArgs e)
    {
      var lGrid = mCurrentControl as PropertyGrid;
      if (lGrid != null)
        lGrid.ResetSelectedProperty();
    }
