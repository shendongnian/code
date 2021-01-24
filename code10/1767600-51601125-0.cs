            private List<CatalogVehicle> GroupResult(IEnumerable<VehicleAndQuote> vehiclesAndQuotes)
            {
                var vehicles = vehiclesAndQuotes
                    .GroupBy(vehicleAndQuote =>
                        new
                        {
                            vehicleAndQuote.Vehicle.VehicleMakeName,
                            vehicleAndQuote.Vehicle.VehicleModelTypeName,
                            vehicleAndQuote.Vehicle.VehicleEdition
                        })
                    .Select(a => new
                    {
                        // DB friendly
                        vehicle = a.First(),
                        plans = a.GroupBy(quote => quote.Quote.YearlyMileage)
                    })
                    .AsEnumerable() // May o may not be needed / passing to LINQ to Objects
                    .Select(a =>
                    {
                        vehicle = _mapper.Map<VehicleAndQuote, CatalogVehicle>(a.vehicle)
                        plans = a.plans.Select(group => _mapper.Map<IEnumerable<VehicleAndQuote>, LeasingPlan>(group))
                        vehicle.LeasingPlans = plans;
                        return vehicle;
                    });
        
                return vehicles.ToList(); // This should be avoided, specially if you are processing a large collection.
            }
