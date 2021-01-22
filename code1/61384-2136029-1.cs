    GeneralTransform gt = 
      TransformToVisual(Application.Current.RootVisual as UIElement);
    Point offset = gt.Transform(new Point(0, 0));
    myFrame.SetStyleAttribute("width", ActualWidth.ToString());
    myFrame.SetStyleAttribute("height", ActualHeight.ToString());
    myFrame.SetStyleAttribute("left", offset.X.ToString());
    myFrame.SetStyleAttribute("top", offset.Y.ToString());
    myFrame.SetStyleAttribute("visibility", "visible");
