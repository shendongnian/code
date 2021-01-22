    public class OnlyIfSet
    {
      static DependencyProperty CreateMap(DependencyProperty prop)
      {
        return DependencyProperty.RegisterAttached(
          prop.Name, prop.PropertyType, typeof(OnlyIfSet), new PropertyMetadata
          {
            PropertyChangedCallback = (obj, e) =>
            {
              if(e.NewValue!=null)
                obj.SetValue(prop, e.NewValue);
              else
              obj.ClearValue(prop);
            }
          });
      }
      public static FontWeight GetFontWeight(DependencyObject obj) { return (FontWeight)obj.GetValue(FontWeightProperty); }
      public static void SetFontWeight(DependencyObject obj, FontWeight value) { obj.SetValue(FontWeightProperty, value); }
      public static readonly DependencyProperty FontWeightProperty =
        CreateMap(TextElement.FontWeightProperty);
      public static double GetFontSize(DependencyObject obj) { return (double)obj.GetValue(FontSizeProperty); }
      public static void SetFontSize(DependencyObject obj, double value) { obj.SetValue(FontSizeProperty, value); }
      public static readonly DependencyProperty FontSizeProperty =
        CreateMap(TextElement.FontSizeProperty);
      ...    
    }
