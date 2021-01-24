	List<Car> cars = new List<Car>()
	{
		new Car(Guid.NewGuid(), "Tesla", true, FuelTypes.Electric),
		new Car(Guid.NewGuid(), "VW", false, FuelTypes.Gassoline),
		new Car(Guid.NewGuid(), "Toyota", false, FuelTypes.Gassoline),
		new Car(Guid.NewGuid(), "Volvo", false, FuelTypes.Diesel),
	};
	var isElectrics = cars.ToLookup(c => c.IsElectric);
	var fuelTypes = cars.ToLookup(c => c.FuelType);
	
	Console.WriteLine($"Electric: {isElectrics[true].Count()}");
	Console.WriteLine($"Gassoline: {fuelTypes[FuelTypes.Gassoline].Count()}");
	Console.WriteLine($"Diesel: {fuelTypes[FuelTypes.Diesel].Count()}");
	Console.WriteLine($"Gassoline & Diesel: {fuelTypes[FuelTypes.Gassoline].Union(fuelTypes[FuelTypes.Diesel]).Count()}");
