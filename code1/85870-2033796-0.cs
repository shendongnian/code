    public bool KeyPressed(Keys key, Keys test)
    {
        return (key & test) == test;
    }
    
    public bool ControlPressed(Keys key)
    {
        return KeyPressed(key, Keys.Control);
    }
    
    public bool AltPressed(Keys key)
    {
        return KeyPressed(key, Keys.Alt);
    }
    
    public bool ShiftPressed(Keys key)
    {
        return KeyPressed(key, Keys.Shift);
    }
