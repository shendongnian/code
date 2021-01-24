    private void ContentTextBox_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
    {
        // NOTE - AcceptsReturn is set to true in XAML.
        if (e.Key == VirtualKey.Enter)
        {
            // If SHIFT is pressed, this next IF is skipped over, so the
            //     default behavior of "AcceptsReturn" is used.
            var keyState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Shift);
            if ((keyState & CoreVirtualKeyStates.Down) != CoreVirtualKeyStates.Down)
            {
                // Mark the event as handled, so the default behavior of 
                //    "AcceptsReturn" is not used.
                e.Handled = true;
            }
        }
    }
    private void ContentTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
    {
        // NOTE - AcceptsReturn is set to true in XAML.
        if (e.Key == VirtualKey.Enter)
        {
            // If SHIFT is pressed, this next IF is skipped over, so the
            //     default behavior of "AcceptsReturn" is used.
            var keyState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Shift);
            if ((keyState & CoreVirtualKeyStates.Down) != CoreVirtualKeyStates.Down)
            {
                // SHIFT is not pressed, so execute my ENTER logic.
                this.Focus(FocusState.Programmatic);
            }
        }
    }
