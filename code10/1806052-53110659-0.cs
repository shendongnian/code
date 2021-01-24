    private void Edit_Checked(object sender, RoutedEventArgs e)
    {
       RightFrame.Content = new SubPage1();
    }
    
    private void Edit_Unchecked(object sender, RoutedEventArgs e)
    {
       RightFrame.Content = new SubPage2();
    }
