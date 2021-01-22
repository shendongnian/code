     KeyboardState keyboardState = Keyboard.GetState();
    
    if (keyboardState.IsKeyUp(keyPressed))
    {
        keyPressed = Keys.None;
    }
    
    if (keyboardState.IsKeyDown(keyPressed))
    {
        return;
    }
    
    // Some additionnal stuff is done according to direction
    if (keyboardState.IsKeyDown(Keys.Up))
    {
        keyPressed = Keys.Up;
    }
    else if (keyboardState.IsKeyDown(Keys.Down))
    {
        keyPressed = Keys.Down;
    }
