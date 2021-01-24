            /// <summary>
            /// This event will also capture any event, But this time you can check if the mouse button clicked is the middle mouse.           /// For now we will just return out of the method
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                 // If the pressed mouse button is either the left or right button
                if(e.ChangedButton == MouseButton.Left || e.ChangedButton == MouseButton.Right)
                {
                    // Exit out of the method
                    return;
                };
            }
    
    /// <summary>
            /// This event will capture every mouse down event, You can add any logic to it.
            /// For now we will just return out of the method
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void Button_MouseWheel(object sender, MouseButtonEventArgs e)
            {
                // If the pressed mouse button is the middle
                if(e.ChangedButton == MouseButton.Middle)
                {
                    // do stuff...
                };
            }
