    public partial class SilverlightControl1 : UserControl {
      public static readonly DependencyProperty ControlsProperty
        = DependencyProperty.Register(
          "Controls",
          typeof(Collection<UIElement>),
          typeof(SilverlightControl1),
          new PropertyMetadata(new Collection<UIElement>())
        );
      public Collection<UIElement> Controls {
        get {
          return (Collection<UIElement>) GetValue(ControlsProperty);
        }
      }
    
    }
