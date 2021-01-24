    private void Dispatcher_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
    {
        if (args.EventType.ToString().Contains("Down"))
        {
            var ctrl = Window.Current.CoreWindow.GetKeyState(VirtualKey.Control);
            var shift = Window.Current.CoreWindow.GetKeyState(VirtualKey.Shift);
            if (ctrl.HasFlag(CoreVirtualKeyStates.Down) && shift.HasFlag(CoreVirtualKeyStates.Down))
            {
                switch (args.VirtualKey)
                {
                    case VirtualKey.V:
    
                        break;
                    case VirtualKey.N:
    
                        break;
                }
            }
        }
    }
