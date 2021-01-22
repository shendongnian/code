    ...
    <TextBox Text="{Binding Object.Value}" KeyDown="TextBox_KeyDown" />
    ...
----------
    public partial class Window1
    {
        private DispatcherTimer timer;
    
        ...
    
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                e.Handled = true;
                var textbox = (TextBox)sender;
                textbox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                (timer = new DispatcherTimer(
                    new TimeSpan(100000), // 10 ms
                    DispatcherPriority.Normal,
                    delegate
                    {
                        textbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        timer.Stop();
                    }, Dispatcher)).Start();
            }
        }
    }
