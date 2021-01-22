    private void CmdEditTextblock_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var grid = ((Grid)((TextBlock)e.OriginalSource).Parent);
            var tbx = (TextBox)grid.Children[1];
            ((TextBlock)e.OriginalSource).Visibility = Visibility.Collapsed;
            tbx.Visibility = Visibility.Visible;
            this.Dispatcher.BeginInvoke((Action)(() => Keyboard.Focus(tbx)), DispatcherPriority.Render);
        }
