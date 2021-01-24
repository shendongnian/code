    public void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
    {
    	CoreVirtualKeyStates keyState = sender.GetAsyncKeyState(args.VirtualKey);
    	if ((int)keyState == 3)
    	{
    		// KeyState is locked and pressed.
    		// Whenever this happens it means the event fired when I actaually pressed this key.
    		// Handle event.
    	}
    	else if ((int)keyState == 2)
    	{
    		// KeyState is locked but not pressed. How if it's not caps lock?
    		// When this happens it's an unwanted duplicate of the last keystroke.
    		// Do not handle event.
    	}
    	else if ((int)keyState == 0)
    	{
    		// Key state is None?!? How can a key that isn't currently down fire a KeyDown event?
    		// This is a phantom delayed rection of a missed event from two keystrokes ago.
    		// Do not handle event.
    	}
    }
