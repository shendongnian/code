    /// <summary>
    /// Used to translate mouse events into touch events, enabling a unified 
    /// input processing pipeline.
    /// </summary>
    /// <remarks>This class originally comes from Blake.NUI - http://blakenui.codeplex.com</remarks>
    public class MouseTouchDevice : TouchDevice, ITouchDevice
    {
        #region Class Members
        private static MouseTouchDevice device;
        public Point Position { get; set; }
        #endregion
        #region Public Static Methods
        public static void RegisterEvents(FrameworkElement root)
        {
            root.PreviewMouseDown += MouseDown;
            root.PreviewMouseMove += MouseMove;
            root.PreviewMouseUp += MouseUp;
            root.LostMouseCapture += LostMouseCapture;
            root.MouseLeave += MouseLeave;
        }
        #endregion
        #region Private Static Methods
        private static void MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.ReportUp();
                device.Deactivate();
                device = null;
            }
            device = new MouseTouchDevice(e.MouseDevice.GetHashCode());
            device.SetActiveSource(e.MouseDevice.ActiveSource);
            device.Position = e.GetPosition(null);
            device.Activate();
            device.ReportDown();
        }
        private static void MouseMove(object sender, MouseEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.Position = e.GetPosition(null);
                device.ReportMove();
            }
        }
        private static void MouseUp(object sender, MouseButtonEventArgs e)
        {
            LostMouseCapture(sender, e);
        }
        static void LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.Position = e.GetPosition(null);
                device.ReportUp();
                device.Deactivate();
                device = null;
            }
        }
        static void MouseLeave(object sender, MouseEventArgs e)
        {
            LostMouseCapture(sender, e);
        }
        #endregion
        #region Constructors
        public MouseTouchDevice(int deviceId) :
            base(deviceId)
        {
            Position = new Point();
        }
        #endregion
        #region Overridden methods
        public override TouchPointCollection GetIntermediateTouchPoints(IInputElement relativeTo)
        {
            return new TouchPointCollection();
        }
        public override TouchPoint GetTouchPoint(IInputElement relativeTo)
        {
            Point point = Position;
            if (relativeTo != null)
            {
                point = this.ActiveSource.RootVisual.TransformToDescendant((Visual)relativeTo).Transform(Position);
            }
            Rect rect = new Rect(point, new Size(1, 1));
            return new TouchPoint(this, point, rect, TouchAction.Move);
        }
        #endregion
    }
