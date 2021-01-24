    public class Segment
    {
        public List<Leg> Legs { get; set; }
        public List<PaxSegment> PaxSegments { get; set; }
    }
    public class Leg
    {
        public FlightDesignator FlightDesignator { get; set; }
    }
    public class FlightDesignator
    {
        public string CarrierCode { get; set; }
        public string FlightNumber { get; set; }
    }
    public class PaxSegment
    {
        public string LiftStatus { get; set; }
    }
