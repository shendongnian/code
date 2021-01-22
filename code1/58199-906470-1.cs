    KeyboardState keyboardState = Keyboard.GetState();
    
    if (keyboardState.IsKeyUp(keyPressed))
    {
        keyPressed = Keys.None;
    }
    
    if (keyboardState.IsKeyDown(keyPressed))
    {
        return;
    }
    
    // Check for new gamepad press
