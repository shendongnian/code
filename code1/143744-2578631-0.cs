    public void Connect()
    {
        if( ModemCommEvent != null)
        ModemCommEvent(this, new ModemCommEventArgs ModemCommEventArgs.eModemCommEvent.Connected));
    }
