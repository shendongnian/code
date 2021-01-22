    <Button PreviewMouseDown="Button_PreviewMouseDown"/>
    private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount >= 2)
        {
            e.Handled = true;
        }
    }
