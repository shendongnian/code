    public class LegalShipTypes
    {
        private readonly byte _numericValue;
        private readonly string _text;
        private LegalShipTypes(byte numericValue, string text)
        {
            _numericValue = numericValue;
            _text = text;
        }
        public byte Value { get { return _numericValue; } }
        public string Text { get { return _text; } }
        public static IEnumerable<LegalShipTypes> All
        {
            get
            {
                return new[] { Frigate, Cruiser, Destroyer, Submarine, AircraftCarrier };
            }
        }
        public static readonly LegalShipTypes Frigate = new LegalShipTypes(1, "Frigate");
        public static readonly LegalShipTypes Cruiser = new LegalShipTypes(2, "Cruiser");
        public static readonly LegalShipTypes Destroyer = new LegalShipTypes(3, "Destroyer");
        public static readonly LegalShipTypes Submarine = new LegalShipTypes(4, "Submarine");
        public static readonly LegalShipTypes AircraftCarrier = new LegalShipTypes(5, "Aircraft Carrier");
    }
