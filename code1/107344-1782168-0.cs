    if(user.Id.HasValue)
    {
        Action openDoor = turnstile.Open;
        Action<LedColor> indicate = led.SetColor;
        // starting async operations
        openDoor.BeginInvoke(openDoor.EndInvoke, null);
        indicate.BeginInvoke(LedColor.Green, indicate.EndInvoke, null);
        // main thread activity.
        MakeRecordToLog();
    }
