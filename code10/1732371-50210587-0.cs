    ...
    myEntryElement.KeyPressEvent += MyHandler;
    ...
    [GLib.ConnectBefore]
    private void MyHandler(object o, KeyPressEventArgs args)
    {
        var evnt = args.Event;
        if (evnt.Key == Key.Down || evnt.Key == Key.Up)
        {
            //do stuff
        }
    }
