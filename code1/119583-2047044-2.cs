    while(tabControlToClear.Controls.Count > 0)
    { 
        var tabPage = tabControlToClear.Controls[0];
        tabControlToClear.Controls.RemoveAt(0);
        tabPage.Dispose(); 
        // Clear out events.
       
        foreach (EventHandler subscriber in tabPage.Click.GetInvocationList())
        {
            tabPage.Click -= subscriber;
        }
    }
