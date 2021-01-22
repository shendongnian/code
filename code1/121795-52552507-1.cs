    private void textBlockName_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var grid = ((Grid) ((TextBlock) sender).Parent);
        var tbx = (TextBox)grid.Children[1];
        ((TextBlock)sender).Visibility = Visibility.Collapsed;
        tbx.Visibility = Visibility.Visible;
        this.Dispatcher.BeginInvoke((Action)(() => Keyboard.Focus(tbx)), DispatcherPriority.Render);
    }
