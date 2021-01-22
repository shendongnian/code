    public class OnlyIfSet : DependencyObject
    {
      public static FontWeight GetFontWeight(DependencyObject obj) { return (FontWeight)obj.GetValue(FontWeightProperty); }
      public static void SetFontWeight(DependencyObject obj, FontWeight value) { obj.SetValue(FontWeightProperty, value); }
      public static readonly DependencyProperty FontWeightProperty = DependencyProperty.RegisterAttached("FontWeight", typeof(FontWeight), typeof(Object), new PropertyMetadata
      {
        PropertyChangedCallback = (obj, e) =>
          {
            if(e.NewValue!=null)
              obj.SetValue(TextElement.FontWeightProperty, e.NewValue);
            else
              obj.ClearValue(TextElement.FontWeightProperty);
          }
      });
    }
