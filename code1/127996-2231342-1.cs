    public class Fleet
    {
        private readonly List<LegalShipTypes> _ships;
        public Fleet()
        {
            _ships = new List<LegalShipTypes>();
        }
        public LegalShipTypes Flagship { get; set; }
        public ICollection<LegalShipTypes> Ships { get { return _ships; } }
    }
    
    ....
    
    var fleet = new Fleet();
    fleet.FlagShip = LegalShipTypes.AircraftCarrier;
    var iDoNotKnowWhyYouWouldNeedThisBut = LegalShipTypes.All.Sum(ship => ship.Value);
    Console.WriteLine("The flagship is a(n) \"{0}\".", fleet.FlagShip.Text);
    if (fleet.FlagShip == LegalShipTypes.AircraftCarrier) // this will work because it's a reference comparison
        Console.WriteLine("This should be true");
