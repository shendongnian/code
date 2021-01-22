    public class SliderTools : DependencyObject
    {
     public static bool GetMoveToPointOnDrag(DependencyObject obj) { return (bool)obj.GetValue(MoveToPointOnDragProperty); }
      public static void SetMoveToPointOnDrag(DependencyObject obj, bool value) { obj.SetValue(MoveToPointOnDragProperty, value); }
      public static readonly DependencyProperty MoveToPointOnDragProperty = DependencyProperty.RegisterAttached("MoveToPointOnDrag", typeof(bool), typeof(SliderTools), new PropertyMetadata
      {
        PropertyChangedCallback = (obj, changeEvent) =>
          {
            var slider = (Slider)obj;
            if((bool)changeEvent.NewValue)
              slider.MouseMove += (obj2, mouseEvent) =>
                {
                  if(mouseEvent.LeftButton == MouseButtonState.Pressed)
                    slider.RaiseEvent(new MouseEventArgs(mouseEvent.MouseDevice, mouseEvent.Timestamp)
                    {
                      RoutedEvent = UIElement.PreviewMouseLeftButtonDownEvent,
                      Source = mouseEvent.Source,
                    });
                };
          }
      });
    }
