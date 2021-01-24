    private void Button_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
       var button = (Button)sender; 
       MessageBox.Show(button.Tag.ToString());
    }
