    private void SwitchView(Panel container, UserControl newView)
    {
        if (container.Controls.Count > 0)
        {
            UserControl oldView = container.Controls[0] as UserControl;
            container.Controls.Remove(0);
            oldView.Dispose();
        }
    
        if (newView != null)
        {
            newView.Dock = Dock.Fill;
            
            // Attach events
            if (newView is ...)
            {
               ...
            }
          
            container.Controls.Add(newView);
        }
    }
