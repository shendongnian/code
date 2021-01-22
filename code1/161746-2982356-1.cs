    private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        Debug.WriteLine((sender as FrameworkElement).Tag + " Preview");
    }
    
    private void MouseDown(object sender, MouseButtonEventArgs e)
    {
        Debug.WriteLine((sender as FrameworkElement).Tag + " Bubble");
    }
