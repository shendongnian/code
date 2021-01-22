    public class VisualBrushSimulator : DependencyObject
    {
      public Visual GetVisual(DependencyObject obj) { return (Visual)obj.GetValue(VisualProperty); }
      public void SetVisual(DependencyObject obj, Visual value) { obj.SetValue(VisualProperty, value); }
      public static readonly DependencyProperty VisualProperty = DependencyProperty.RegisterAttached("Visual", typeof(Visual), typeof(VisualBrushSimulator), new PropertyMetadata
      {
        PropertyChangedCallback = (obj, e) =>
        {
          int width=1000;
          int height=1000;
          var bitmap = new WritableBitmap(width, height);
          bitmap.Render((Visual)e.NewValue, new ScaleTransform { ScaleX = width, ScaleY = height });
          ((ImageBrush)obj).ImageSource = bitmap;
        }
      });
    }
