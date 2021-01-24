    public void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
    {
    	CoreVirtualKeyStates keyState = sender.GetAsyncKeyState(args.VirtualKey);
    	if ((int)keyState == 3)
    	{
    		// KeyState is locked and pressed, handle event.
    	}
    	else if ((int)keyState == 2)
    	{
    	    // KeyState is locked but not pressed???  Do nothing, as this represents
    		// an unwanted delayed and/or duplicate keystroke.
    	}
    }
