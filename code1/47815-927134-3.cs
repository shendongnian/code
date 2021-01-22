    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace MapTest
    {
        public partial class Window1 : Window
        {
            private Point origin;
            private Point start;
    
            public Window1()
            {
                InitializeComponent();
    
                TransformGroup group = new TransformGroup();
    
                ScaleTransform xform = new ScaleTransform();
                group.Children.Add(xform);
    
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(tt);
    
                image.RenderTransform = group;
    
                image.MouseWheel += image_MouseWheel;
                image.MouseLeftButtonDown += image_MouseLeftButtonDown;
                image.MouseLeftButtonUp += image_MouseLeftButtonUp;
                image.MouseMove += image_MouseMove;
            }
    
            private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                image.ReleaseMouseCapture();
            }
    
            private void image_MouseMove(object sender, MouseEventArgs e)
            {
                if (!image.IsMouseCaptured) return;
    
                var tt = (TranslateTransform) ((TransformGroup) image.RenderTransform).Children.First(tr => tr is TranslateTransform);
                Vector v = start - e.GetPosition(border);
                tt.X = origin.X - v.X;
                tt.Y = origin.Y - v.Y;
            }
    
            private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                image.CaptureMouse();
                var tt = (TranslateTransform) ((TransformGroup) image.RenderTransform).Children.First(tr => tr is TranslateTransform);
                start = e.GetPosition(border);
                origin = new Point(tt.X, tt.Y);
            }
    
            private void image_MouseWheel(object sender, MouseWheelEventArgs e)
            {
                TransformGroup transformGroup = (TransformGroup) image.RenderTransform;
                ScaleTransform transform = (ScaleTransform) transformGroup.Children[0];
    
                double zoom = e.Delta > 0 ? .2 : -.2;
                transform.ScaleX += zoom;
                transform.ScaleY += zoom;
            }
        }
    }
