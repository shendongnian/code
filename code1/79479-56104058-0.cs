    public Shortcut(KeyEventArgs e) : this(e.Key == System.Windows.Input.Key.System ? e.SystemKey : e.Key, Keyboard.Modifiers, false) { }
        
    public Shortcut(Key key, ModifierKeys modifiers, bool createDisplayString)
    {
        ...
    } 
