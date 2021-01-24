    static void Main(string[] args)
    {
        NMEA2OSG nMEA2OSG = new NMEA2OSG();
        nMEA2OSG.NorthingEastingReceived += NMEA2OSG_NorthingEastingReceived;
        nMEA2OSG.NatGridRefReceived += NMEA2OSG_NatGridRefReceived;
        bool coord = nMEA2OSG.Transform(52.3, -0.1, 50);
        Console.ReadKey();
    }
    private static void NMEA2OSG_NatGridRefReceived(string ngr)
    {
        Console.WriteLine("NatGrid: {0}", ngr);
    }
    private static void NMEA2OSG_NorthingEastingReceived(double northing, double easting)
    {
        Console.WriteLine("Northing = {0}, Easting = {1}", northing, easting);
    }
