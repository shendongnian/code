    public class Radial
    {
        public int radialNumber { get; set; }
        public double azimuthDeg { get; set; }
        public double elevationDeg { get; set; }
        public int duration { get; set; }
        public List<double> gateIntensity { get; set; }
    }
    
    public class RootObject
    {
        public int sweepIndex { get; set; }
        public int totalRadials { get; set; }
        public double beamWidth { get; set; }
        public long startingUnixtime { get; set; }
        public long endingUnixtime { get; set; }
        public int totalGatesPerRay { get; set; }
        public double gateDepthMeters { get; set; }
        public double distanceToFirstGateMeters { get; set; }
        public double meanElevationDeg { get; set; }
        public double originLatitude { get; set; }
        public double originLongitude { get; set; }
        public double originAltitude { get; set; }
        public int deviantOriginCount { get; set; }
        public List<Radial> radials { get; set; }
    }
