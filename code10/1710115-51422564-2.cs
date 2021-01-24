     class LocationFetcher : ILocationFetcher
     {
        public System.Drawing.PointF GetCoordinates(global::Xamarin.Forms.VisualElement element)
        {
            var renderer = Platform.GetRenderer(element);
            var nativeView = renderer.NativeView;
            var rect = nativeView.Superview.ConvertPointToView(nativeView.Frame.Location, null);
            return new System.Drawing.PointF((int)Math.Round(rect.X), (int)Math.Round(rect.Y));
        }
    }
