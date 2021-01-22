    Hotkey hk = new Hotkey();
    hk.KeyCode = Keys.1;
    hk.Windows = true;
    hk.Pressed += delegate { Console.WriteLine(“Windows+1 pressed!”); };
    if (!hk.GetCanRegister(myForm))
    { Console.WriteLine(“Whoops, looks like attempts to register will fail or throw an exception, show an error/visual user feedback”); }
    else
    { hk.Register(myForm); }
    // .. later, at some point
    if (hk.Registered)
    { hk.Unregister(); }
