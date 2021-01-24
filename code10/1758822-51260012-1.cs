    private void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
    {
        if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
        {
            overlay.Visibility = Visibility.Visible;
        }
        else
        {
            overlay.Visibility = Visibility.Collapsed;
        }
    }
    
