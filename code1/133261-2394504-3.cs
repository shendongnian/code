    public static void Main (string[] args)
    {
        Application.Init();
        
        X11Hotkey hotkey = new X11Hotkey(Gdk.Key.A, Gdk.ModifierType.ControlMask);
        hotkey.Pressed += HotkeyPressed;;
        hotkey.Register();
        
        Application.Run();
        
        hotkey.Unregister();
    }
                   
    private static void HotkeyPressed(object sender, EventArgs e)
    {
        Console.WriteLine("Hotkey Pressed!");
    }
