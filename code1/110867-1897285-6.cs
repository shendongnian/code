    public static class ControlExtensions
    {
        public static Image DrawToImage(this Control control)
        {
            return Utilities.CaptureWindow(control.Handle);
        }
    }
