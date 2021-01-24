    static class ControlExtensions
    {
        ///<summary>
        /// Returns the position of the point in screen coordinates of that control instead
        /// of the main-screen coordinates
        ///</summary>
        public static Point PointToCurrentScreen(this Control self, Point location)
        {
            var screenBounds = Screen.FromControl(self).Bounds;
            var globalCoordinates = self.PointToScreen(location);
            return new Point(globalCoordinates.X - screenBounds.X, globalCoordinates.Y - screenBounds.Y);
        }
    }
