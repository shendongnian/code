    // A delegate type for hooking up change notifications.
    public delegate void MagicEventHandler();
    public event MagicEventHandler MagicButttonClicked;    
    // Invoke the event, this inside your button click event handler:
    void Button1_OnClick(EventArgs e) 
    {
        if (Changed != null) MagicButttonClicked();
    }
