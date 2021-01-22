        private void Popup_Opened(object sender, EventArgs events)
        {
            Popup popup = (Popup)sender;
            
            // Get window to make popop follow it when user change window's location.
            Window w = Window.GetWindow(popup);
            // Popups are always on top, so when another window gets focus, we
            // need to close all popups.
            w.Deactivated += delegate (object s, EventArgs e)
            {
                popup.IsOpen = false;
            };
            // When our dialog gets focus again, we show it back.
            w.Activated += delegate (object s, EventArgs e)
            {
                popup.IsOpen = true;
            };
         }
