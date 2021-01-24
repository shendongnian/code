    private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
    {
        if (sender is Rectangle rectangle)
        {
            if (string.IsNullOrEmpty(rectangle.ToolTip.ToString()))
            {
                rectangle.Visibility = Visibility.Collapsed;
            }
        }
    }
