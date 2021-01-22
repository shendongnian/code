    protected void txtblk_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextBox txt = (TextBox)((Grid)((TextBlock)sender).Parent).Children[1];
        txt.Visibility = Visibility.Visible;
        ((TextBlock)sender).Visibility = Visibility.Collapsed;
    }
    
    protected void txtbox_LostFocus(object sender, RoutedEventArgs e)
    {
        TextBlock tb = (TextBlock)((Grid)((TextBox)sender).Parent).Children[0];
        tb.Text = ((TextBox)sender).Text;
        tb.Visibility = Visibility.Visible;
        ((TextBox)sender).Visibility = Visibility.Collapsed;
    }
