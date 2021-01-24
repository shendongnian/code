    KeyBinding n = new KeyBinding() { Modifiers = ModifierKeys.Control, Key = Key.N };
    KeyBinding o = new KeyBinding() { Modifiers = ModifierKeys.Control, Key = Key.O };
    KeyBinding s = new KeyBinding() { Modifiers = ModifierKeys.Control, Key = Key.S };
    KeyBinding w = new KeyBinding() { Modifiers = ModifierKeys.Control, Key = Key.W };
    BindingOperations.SetBinding(n, InputBinding.CommandProperty, new Binding("NewProgramCommand"));
    BindingOperations.SetBinding(o, InputBinding.CommandProperty, new Binding("OpenProgramCommand"));
    BindingOperations.SetBinding(s, InputBinding.CommandProperty, new Binding("SaveProxyCommand"));
    BindingOperations.SetBinding(w, InputBinding.CommandProperty, new Binding("CloseProxyCommand"));
    InputBindings.AddRange(new KeyBinding[4] { n, o, s, w });
