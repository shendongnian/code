    public class JourneyLegFromTo : JourneyLeg
    {
        [Required]
        public LegStop From { get; set; }
        [Required]
        public LegStop To { get; set; }
    }
    public class WalkingLeg : JourneyLegFromTo 
    {
        ...
    }
    public class VehicleLeg : JourneyLegFromTo 
    {
        ...
    }
