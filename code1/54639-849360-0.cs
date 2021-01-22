    [GLib.ConnectBefore]
    void OnTreeViewButtonPressEvent(object sender, ButtonPressEventArgs e)
    {
        if (e.Type == Gdk.EventType.TwoButtonPress)
        {
            // double click
        }
    }    
