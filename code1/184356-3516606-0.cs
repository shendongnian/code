    private void MouseOverHarbor(object sender, MouseEventArgs e)
    {
        List<UIElement> list = VisualTreeHelper.FindElementsInHostCoordinates(e.GetPosition(null),
                               LayoutRoot as UIElement) as List<UIElement>;
        foreach (var item in list)
        {
            if (item is Path)
            {
                item.Opacity = 0.25;    // Set state opacity
            }
            else if (item is Ellipse)
            {
                item.Opacity = 0.25;    // Set harbour opacity
            }
        }
    }
