    public class SelectableTextBlock : TextBox
    {
        public SelectableTextBlock() : base()
        {
            this.AddHandler(SelectableTextBlock.KeyDownEvent, new RoutedEventHandler(HandleHandledKeyDown), true);
        }
        public void HandleHandledKeyDown(object sender, RoutedEventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if (ke.Key == Key.Space)
            {
                ke.Handled = false;
            }
        }
        ...
    }
