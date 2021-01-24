    [Pseudocode]
    if(OnlyOneKeyPressed())
    {
        savedPressedKey = SaveKeyPressed(GetPressedKey());
        pressedKey = GetPressedKey();
    }
    else if(TwoKeysPressed())
        pressedKey = GetAllPressedKeys().Exclude(savedPressedKey);
    
    if(pressedKey == "ArrowUp" && ...)
    ...
    ...
