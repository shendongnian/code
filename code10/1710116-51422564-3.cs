    class LocationFetcher : ILocationFetcher
    {
        public System.Drawing.PointF GetCoordinates(global::Xamarin.Forms.VisualElement element)
        {
            var renderer = Platform.GetRenderer(element);
            var nativeView = renderer.View;
            var location = new int[2];
            var density = nativeView.Context.Resources.DisplayMetrics.Density;
    
            nativeView.GetLocationOnScreen(location);
            return new System.Drawing.PointF(location[0] / density, location[1] / density);
        }
    }
