    var deliveries = new Delivery[] { };
    var internalDrivers = new Driver[] { /*...*/ };
    var externalDrivers = new Driver[] { /*...*/ };
    var deliveryModels = deliveries.Where(dl => dl.DriverType == "Internal")
        .Join(internalDrivers, delivery => delivery.DriverId, driver => driver.Id,
            (dl, dr) => new DeliveryModel {DeliveryId = dl.Id, DriverName = dr.DriverName})
        .Concat(deliveries.Where(dl => dl.DriverType == "External")
            .Join(externalDrivers, delivery => delivery.DriverId, driver => driver.Id,
                (dl, dr) => new DeliveryModel {DeliveryId = dl.Id, DriverName = dr.DriverName}));
    
    //....
    public class  DeliveryModel
    {
        public int DeliveryId { get; set; }
        public string DriverName { get; set; }
    }
