    private void Dispatcher_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
    {
        if (args.EventType.ToString().Contains("Down"))
        {
            var ctrl = Window.Current.CoreWindow.GetKeyState(VirtualKey.Control);
            if (ctrl.HasFlag(CoreVirtualKeyStates.Down))
            {
                switch (args.VirtualKey)
                {
                    case VirtualKey.V:
                        ViewOrders_Tapped(this, null);
                        break;
                    case VirtualKey.N:
                        NewOrder_Tapped(this, null);
                        break;
                }
            }
        }
    }
