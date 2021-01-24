    public void FocusOnElement(FrameworkElement elementToFocus)
    {
        Point center = new Point(elementToFocus.ActualWidth / 2.0, elementToFocus.ActualHeight / 2.0);
        Point newPosition = elementToFocus.TranslatePoint(center, ShowcasePath);
        ellipseGeometry.Center = newPosition;
    }
