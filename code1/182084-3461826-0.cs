    Dictionary<Key, Function> map = new Dictionary<Key, Function>();
    
    map.Add(Key.Orange, Function.Orange);
    map.Add(Key.Blue, Function.Blue);
    map.Add(Key.Shift, Function.Shift);
    map.Add(Key.Control, Function.Control);
    
    foreach(var pair in map)
    {
        if (PsionTeklogix.Keyboard.Keyboard.GetModifierKeyState(map.Key) == KeyState.Lock)
        {
            PsionTeklogix.Keyboard.Keyboard.InjectKeyboardCommand(map.Value, 0, 0);
        }
    }
