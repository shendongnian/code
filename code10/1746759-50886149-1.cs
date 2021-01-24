    public void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
    {
    	CoreVirtualKeyStates keyState = sender.GetAsyncKeyState(args.VirtualKey);
    	if ((int)keyState == 3)
    	{
    		// KeyState is locked and pressed. This is what it should always be if it fires KeyDown.
    		// Handle event.
    	}
    	else if ((int)keyState == 2)
    	{
    		// KeyState is locked but not pressed. How can this happen? Don't know, but I know this represents
    		// a delayed reaction to an earlier keystroke, which is better off ignored.
    		// Do not handle event.
    	}
    	else if ((int)keyState == 0)
    	{
    		// Key state is None?!? How can a key that isn't currently down fire a KeyDown event?
    		// Do not handle event.
    	}
    }
