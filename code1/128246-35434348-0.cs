     public static class Ext
    {
        public static Size GetNativePrimaryScreenSize(this Window window)
        {
            PresentationSource mainWindowPresentationSource = PresentationSource.FromVisual(window);
            Matrix m = mainWindowPresentationSource.CompositionTarget.TransformToDevice;
            var dpiWidthFactor = m.M11;
            var dpiHeightFactor = m.M22;
            double screenHeight = SystemParameters.PrimaryScreenHeight * dpiHeightFactor;
            double screenWidth = SystemParameters.PrimaryScreenWidth * dpiWidthFactor;
            return new Size(screenWidth, screenHeight);
        }
    }
