        public static Point getScreenDPI(Visual v)
        {
            //System.Windows.SystemParameters
            PresentationSource source = PresentationSource.FromVisual( v );
            Point ptDpi;
            if (source != null)
            {
                ptDpi = new Point( 96.0 * source.CompositionTarget.TransformToDevice.M11,
                                   96.0 * source.CompositionTarget.TransformToDevice.M22  );
            }
            else
                ptDpi = new Point(96d, 96d); //default value.
            return ptDpi;
        }
