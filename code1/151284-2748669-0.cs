    using System.Windows;
    using System.Windows.Input;
    using Petzold.Media3D;
    
    namespace _3DTester
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
    
            /* This MouseDown event handler prints:
              (1) the current position of the mouse
              (2) the 3D mouse location on the ground plane (z = 0)
              (3) the 2D mouse location converted from the 3D location */
            private void Window_MouseDown(object sender, MouseEventArgs e)
            {
                var range = new LineRange();
                var isValid = ViewportInfo.Point2DtoPoint3D(Viewport, e.GetPosition(Viewport), out range);
                if (!isValid)
                    MouseLabel.Content = "(no data)";
                else
                {
                    var point3D = range.PointFromZ(0);
                    var point = ViewportInfo.Point3DtoPoint2D(Viewport, point3D);
                    MouseLabel.Content = e.GetPosition(Viewport) + "\n" + point3D + "\n" + point;
                }
            }
        }
    }
