    public void FocusOnElement(FrameworkElement element)
    {
        Point center = new Point(element.ActualWidth / 2, element.ActualHeight / 2);
        Point newPosition = element.TranslatePoint(center, ShowcasePath);
        ellipseGeometry.Center = newPosition;
    }
