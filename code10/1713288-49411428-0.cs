    private bool _isToolTipVisible = true;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Style style = new Style(typeof(ToolTip));
        style.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
        style.Seal();
        foreach (Window window in Application.Current.Windows)
        {
            if (_isToolTipVisible)
            {
                window.Resources.Add(typeof(ToolTip), style); //hide
                _isToolTipVisible = false;
            }
            else
            {
                window.Resources.Remove(typeof(ToolTip)); //show
                _isToolTipVisible = true;
            }
        }
    }
