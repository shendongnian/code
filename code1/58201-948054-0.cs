    KeyboardState oldState;
    ...
    var newState = Keyboard.GetState();
    
    if (newState.IsKeyDown(Keys.Down) && !oldState.IsKeyDown(Keys.Down))
    {
        // the player just pressed down
    }
    else if (newState.IsKeyDown(Keys.Down) && oldState.IsKeyDown(Keys.Down))
    {
        // the player is holding the key down
    }
    else if (!newState.IsKeyDown(Keys.Down) && oldState.IsKeyDown(Keys.Down))
    {
        // the player was holding the key down, but has just let it go
    }
    oldState = newState;
