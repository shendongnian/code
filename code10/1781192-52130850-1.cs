    var busses = context.Set<BusEntity>().Where(x => x.IsDriving);
    var passengers = context.Set<PassengerEntity>().Where(x => x.Awake);
    var carryOns = context.Set<CarryOnEntity>();
    var luggages = context.Set<LuggageEntity>();
    var passengerJoins = passengers.GroupJoin(
            carryOns,
            x => x.PassengerID,
            y => y.PassengerID,
            (x, y) => new { Passenger = x, CarryOns = y }
        )
        .SelectMany(
            x => x.CarryOns.DefaultIfEmpty(),
            (x, y) => new { Passenger = x.Passenger, CarryOns = x.CarryOns }
        ).GroupJoin(
            luggages,
            x => x.Passenger.PassengerID,
            y => y.PassengerID,
            (x, y) => new { Passenger = x.Passenger, CarryOns = x.CarryOns, Luggages = y }
        )
        .SelectMany(
            x => x.Luggages.DefaultIfEmpty(),
            (x, y) => new { Passenger = x.Passenger, CarryOns = x.CarryOns, Luggages = x.Luggages }
        );
    var bussesToPassengers = busses.GroupJoin(
            passengerJoins,
            x => x.BusID,
            y => y.Passenger.BusID,
            (x, y) => new { Bus = x, Passengers = y }
        )
        .SelectMany(
            x => x.Passengers.DefaultIfEmpty(),
            (x, y) => new { Bus = x.Bus, Passengers = x.Passengers }
        )
        .GroupBy(x => x.Bus);
    var rez = bussesToPassengers.ToList()
        .Select(x => x.First().Bus)
        .ToList();
