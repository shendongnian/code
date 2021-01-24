    static class PopupMouseEnhance
    {
        // This is the usual attached property stuff...
        public static bool GetEnabled(UIElement element)
        {
            return (bool)element.GetValue(EnabledProperty);
        }
        public static void SetEnabled(UIElement element, bool value)
        {
            element.SetValue(EnabledProperty, value);
        }
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached(
                "Enabled",
                 typeof(bool),
                 typeof(PopupMouseEnhance),
                 new PropertyMetadata(false, EnabledChanged));
        // This method is called when you set the attached property value
        private static void EnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Popup popup = d as Popup;
            if (popup == null)
            {
                // We don't support anything but Popups
                throw new InvalidOperationException("This attached property can only be set on a Popup object.");
            }
            if ((bool)e.NewValue)
            {
                // if the attached property value is 'true', then enable our trick...
                popup.Opened += Popup_Opened;
                // This is to prevent memory leaks when Popups get removed from the visual tree
                popup.Unloaded += Popup_Unloaded;
            }
            else
            {
                // ... otherwise, disable
                popup.Unloaded -= Popup_Unloaded;
                popup.Opened -= Popup_Opened;
            }      
        }
    
        private static void Popup_Unloaded(object sender, RoutedEventArgs e)
        {
            // When a Popup is completely unloaded, unsubscribe from everything!
            // This event won't be raised on app's shutdown, but in that case
            // we don't bother with memory leaks anyway.
            Popup p = (Popup)sender;
            p.Unloaded -= Popup_Unloaded;
            p.Opened -= Popup_Opened;      
        }
        private static void Popup_Opened(object sender, EventArgs e)
        {
            Popup p = (Popup)sender;
            // Okay, the Popup is shown. Enable our tricks!
            // First, we determine the window we will monitor:
            Window w = Window.GetWindow(p);
            if (w != null)
            {
                // Then, we need a HwndSource instance of that window
                // to be able to insert our custom Message Hook
                HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(w).Handle);
               if (source != null)
               {
                   // All set, enable our custom window helper!
                   WindowHelper.Enable(source, w, p);
               }
           }
        }
        // Our custom helper class. The magic occurs here.
        private class WindowHelper
        {
            private readonly HwndSource mHwndSource;
            private readonly Window mWindow;
            private WindowHelper(HwndSource hwndSource, Window window)
            {
                mHwndSource = hwndSource;
                mWindow = window;
            }
            public static void Enable(HwndSource hwndSource, Window window, Popup popup)
            {
                // Create an instance of our helper class...
                WindowHelper helper = new WindowHelper(hwndSource, window);
                // ... and set a Message Hook to our custom method.
                hwndSource.AddHook(helper.WndProc);
                // Don't forget to disable the magic, when the popup is closed.
                popup.Closed += helper.Popup_Closed;
            }
            private void Popup_Closed(object sender, EventArgs e)
            {
                // The Popup is closed now - disable all!
                Popup p = (Popup)sender;
                p.Closed -= Popup_Closed;
                mHwndSource.RemoveHook(WndProc);
            }
            // This is our custom Windows messages hook.
            // This method will be called whenever our window receives a message.
            private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                // We're only interested in the WM_SETCURSOR message.
                // It will be sent to our window when the user moves the mouse
                // cursor around and clicks the mouse buttons.
                if (msg != NativeConstants.WM_SETCURSOR)
                {
                    return IntPtr.Zero;
                }
                // Determine the necessary parameters.
                // See MSDN topic on WM_SETCURSOR for details.
                var mouseMessage = ((int)lParam & 0xFFFF0000) >> 16;
                var hitTest = (int)lParam & 0xFFFF;
                switch (hitTest)
                {
                    // Only continue if the mouse is over
                    // 'minimize', 'maximize', 'close'
                    case NativeConstants.HTMINBUTTON:
                    case NativeConstants.HTMAXBUTTON:
                    case NativeConstants.HTCLOSE:
                        break;
                    default:
                        // Otherwise, do nothing.
                        return IntPtr.Zero;
                }
                // If the user clicks outside the Popup,
                // a WM_MOUSEMOVE message will be transmitted via WM_SETCURSOR.
                // So if we've received something other - ignore that.
                if (mouseMessage != NativeConstants.WM_MOUSEMOVE)
                {
                    return IntPtr.Zero;
                }
 
                // We need to perform these actions manually,
                // because the window will not receive the corresponding messages
                // on first mouse click (when the Popup is still open).
                switch (hitTest)
                {
                    case NativeConstants.HTMINBUTTON:
                        mWindow.WindowState = WindowState.Minimized;
                        break;
                    case NativeConstants.HTMAXBUTTON:
                        mWindow.WindowState = WindowState.Maximized;
                        break;
                    case NativeConstants.HTCLOSE:
                        mWindow.Close();
                        break;
                }
                // We always return 0, because we don't want any side-effects
                // in the message processing.
                return IntPtr.Zero;
            }
        }
        private static class NativeConstants
        {
            public const int WM_SETCURSOR = 0x020;
            public const int WM_MOUSEMOVE = 0x200;
            public const int HTMINBUTTON = 8;
            public const int HTMAXBUTTON = 9;
            public const int HTCLOSE = 20;
        }
    }
