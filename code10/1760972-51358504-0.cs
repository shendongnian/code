    private void Button_Click(object sender, RoutedEventArgs e)
    {
        UserControl2 uc2 = grd_Main.Children.OfType<UserControl2>().FirstOrDefault();
        if (uc2 != null)
        {
            UserControl1 uc1 = uc2.grd_ParentOfUserControl1.Children.OfType<UserControl1>().FirstOrDefault();
            if (uc1 != null)
            {
                uc1.theButton.Content = "the text...";
            }
        }
    }
