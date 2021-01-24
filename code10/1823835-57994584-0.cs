    public class Airport
    {
        public IdGraphType Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public PlaneType Plane { get; set; }
    }
    
    public class AirportType : ObjectGraphType<Airport>
    {
        public AirportType()
        {
            Name = "Airport";
    
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Airport.");
            Field(x => x.Name).Description("The name of the Airport");
            Field(x => x.Location).Description("The Location of the Airport");
            Field(x => x.Plane, nullable: true, type: typeof(ListGraphType<PlaneType>)).Description("Aiports Planes");
        }
    }
    
    public class Pilot
    {
        public IdGraphType Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IdGraphType PlaneId { get; set; }
    }
    
    public class PilotType : ObjectGraphType<Pilot>
    {
        public PilotType()
        {
            Name = "Pilot";
    
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Pilot.");
            Field(x => x.Name).Description("The name of the Pilot");
            Field(x => x.Surname).Description("The surname of the Pilot");
            Field(x => x.PlaneId, nullable: true).Description("The parent Plane");
        }
    }
    
    public class Plane
    {
        public IdGraphType Id { get; set; }
        public string Model { get; set; }
        public string Callsign { get; set; }
        public string AirportId { get; set; }
        public PilotType Pilot { get; set; }
    }
    
    public class PlaneType : ObjectGraphType<Plane>
    {
        public PlaneType()
        {
            Name = "Plane";
    
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Plane.");
            Field(x => x.Model).Description("The model of the Plane");
            Field(x => x.Callsign).Description("The callsign of the Plane");
            Field(x => x.AirportId, nullable: true).Description("The parent Aiport");
            Field(x => x.Pilot, nullable: true, type: typeof(ListGraphType<PilotType>)).Description("The Planes Pilots");
        }
    }
