    namespace dragdropButton
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            /// Tells whether the button is being pressed or not
            private bool buttonPressed;
    
            #region Imports method to determinate the mouse position
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool GetCursorPos(ref Win32Point pt);
    
            [StructLayout(LayoutKind.Sequential)]
            internal struct Win32Point
            {
                public Int32 X;
                public Int32 Y;
            };
    
            /// <summary>
            /// Obtains the mouse current position
            /// </summary>
            /// <returns>Position coordinates</returns>
            public static Point GetMousePosition()
            {
                Win32Point w32Mouse = new Win32Point();
                GetCursorPos(ref w32Mouse);
                return new Point(w32Mouse.X, w32Mouse.Y);
            }
            #endregion
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            /// <summary>
            /// Calculates the distance between two 2-dimensional points A and B
            /// </summary>
            /// <param name="pt">Point A</param>
            /// <param name="x">X coordinate of B</param>
            /// <param name="y">Y coordinate of B</param>
            /// <returns></returns>
            private double EuclideanDist(Point pt, double x, double y)
            {
                return Math.Sqrt(Math.Pow(pt.X - x, 2) + Math.Pow(pt.Y - y, 2));
            }
    
            /// <summary>
            /// Maps the left margin to the current mouse position
            /// </summary>
            /// <param name="pt">Mouse current position</param>
            /// <returns>Left margin</returns>
            private double GetLeftMargin(Point pt)
            {
                double x = 0;
                double y = pt.Y;
                return EuclideanDist(pt, x, y);
            }
    
            /// <summary>
            /// Maps the top margin to the current mouse position
            /// </summary>
            /// <param name="pt">Mouse current position</param>
            /// <returns>Top margin</returns>
            private double GetTopMargin(Point pt)
            {
                double x = pt.X;
                double y = 0;
                return EuclideanDist(pt, x, y);
            }
    
            /// <summary>
            /// Fires when mouse moves within this WPF window
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
            {
                // if button is being pressed
                if (buttonPressed)
                {
                    // get the mouse current position
                    Point pt = GetMousePosition();
    
                    // set the new button position
                    this.button.Margin = new Thickness(GetLeftMargin(pt), GetTopMargin(pt), 0, 0);
                }
            }
    
            /// <summary>
            /// Fires whe button is pressed by mouse right click
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void button_MouseDown(object sender, MouseButtonEventArgs e)
            {
                buttonPressed = true;
            }
    
            /// <summary>
            /// Firew when the button is released by mouse right click
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void button_MouseUp(object sender, MouseButtonEventArgs e)
            {
                buttonPressed = false;
            }
        }
    }
