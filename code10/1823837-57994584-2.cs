    public class Plane
    {
        public IdGraphType Id { get; set; }
        public string Model { get; set; }
        public string Callsign { get; set; }
        public string AirportId { get; set; }
        public PilotType Pilot { get; set; }
        public Connection<Pilot> PilotConnection { get; set; }
    
        public Plane()
        {
            PilotConnection = new Connection<Pilot>
            {
                TotalCount = 3,
    
                PageInfo = new PageInfo
                {
                    HasNextPage = false,
                    HasPreviousPage = false,
                    StartCursor = "0",
                    EndCursor = "2",
                },
    
                Edges = new List<Edge<Pilot>>
                {
                    new Edge<Pilot> {Cursor = "0", Node = new Pilot { Name = "Johnny", Id = new IdGraphType() }},
                    new Edge<Pilot> {Cursor = "1", Node = new Pilot { Name = "Ronny", Id = new IdGraphType() }},
                    new Edge<Pilot> {Cursor = "2", Node = new Pilot {Name = "Jimmy", Id = new IdGraphType() }}
                }
            };
        }
    }
