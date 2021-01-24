    private SolidColorBrush _b1 = (SolidColorBrush)new BrushConverter().ConvertFromString("#95305D");
    private SolidColorBrush _b2 = (SolidColorBrush)new BrushConverter().ConvertFromString("#3E7A61");
    private int clickCount = 0;
    public void Rect_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        clickCount++;
        RMaximize.Fill = (clickCount % 2 == 1) ? _b2 : b1;
    }
