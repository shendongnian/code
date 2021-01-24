    delegate void RemoveControlDelegate(Control controlToRemove);
    private void RemoveControl(Control control)
    {
       if (InvokeRequired)
       {
           BeginInvoke(new RemoveControlDelegate(RemoveControl), control);
       }
       else
       {
           MainPanel.Controls.Remove(control);
       }
    }
    foreach (var toRemove in controls)
         RemoveControl(toRemove);
