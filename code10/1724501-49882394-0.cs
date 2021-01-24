    class Shipment
    {
        public List<ShipmentTrackingNUmbers> ShipmentTrackingNUmbers { get; set; }
        public string dtDateShipped { get; set; }
        public string dSPRatedWeight { get; set; }
        public string nMBTotalBoxes { get; set; }
        public string sShipToAddressLine2 { get; set; }
    }
    public class ShipmentTrackingNUmbers
    {
        public string sTrackingNumber { get; set; }
    }
