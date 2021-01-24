    public class JourneyLeg
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public LegType Type { get; set; }
    }
    // You may want another name...
    public class JourneyFromToLeg : JourneyLeg
    {
        [Required]
        public LegStop From { get; set; }
        [Required]
        public LegStop To { get; set; }
    }
    public class VehicleLeg : JourneyFromToLeg 
    {
        [Required]
        public ModalityType Modality { get; set; }
    }
    public class WalkingLeg : JourneyFromToLeg 
    {
        [Required]
        public string Description { get; set; }
    }
