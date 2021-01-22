    public class MyMapMode : Microsoft.Maps.MapControl.Core.MercatorMode
    {
        public Range<double> MapZoomRange = new Range<double>(1.0, 10.0);
        protected override Range<double> GetZoomRange(Location center)
        {
            return this.MapZoomRange;
        }
    }
