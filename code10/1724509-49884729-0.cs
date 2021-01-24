    public class OrderedProduct
        {
            public Guid Id { get; set; }
    
            //other
            public Guid ShipmentId { get; set; }
            public Shipment other { get; set; }//Change
    
        }
