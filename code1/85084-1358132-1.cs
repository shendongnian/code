    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace WpfApplication5
    {
      public class FreeFormContentControl : ContentControl
      {
        public Geometry FormGeometry
        {
          get { return (Geometry)GetValue(FormGeometryProperty); }
          set { SetValue(FormGeometryProperty, value); }
        }
    
        public static readonly DependencyProperty FormGeometryProperty =
          DependencyProperty.Register("FormGeometry", typeof(Geometry), typeof(FreeFormContentControl), new UIPropertyMetadata(null));
    
        static FreeFormContentControl()
        {
          DefaultStyleKeyProperty.OverrideMetadata(
            typeof(FreeFormContentControl),
            new FrameworkPropertyMetadata(typeof(FreeFormContentControl))
            );
        }
      }
    }
