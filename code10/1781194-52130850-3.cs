    var bus = context.Set<BusEntity>().Where(x => x.IsDriving).ToList();
    var busIDs = bus.Select(x => x.BusID).ToList();
    var passengers = context.Set<PassengerEntity>().Where(x => x.IsAwake && busIDs.Contains(x.BusID)).ToList();
    var passengerIDs = passengers.Select(x => x.PassengerID).ToList();
    var carryOns = context.Set<CarryOnEntity>().Where(x => passengerIDs.Contains(x.PassengerID)).ToList();
    var luggages = context.Set<LuggageEntity>().Where(x => passengerIDs.Contains(x.PassengerID)).ToList();
    passengers.ForEach(x => {
        x.CarryOns = carryOns.Where(y => y.PassengerID == x.PassengerID).ToList();
        x.Luggages = luggages.Where(y => y.PassengerID == x.PassengerID).ToList();
    });
    bus.ForEach(x => x.Passengers = passengers.Where(y => y.BusID == x.BusID).ToList());
