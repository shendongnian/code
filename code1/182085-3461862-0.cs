    foreach (Key key in Enum.GetValues(typeof(Key))) 
    {
        if (PsionTeklogix.Keyboard.Keyboard.GetModifierKeyState(key) == KeyState.Lock)
        {
            PsionTeklogix.Keyboard.Keyboard.InjectKeyboardCommand((Function)Enum.Parse(typeof(Function), key.ToString()), 0, 0);
        }
    }
