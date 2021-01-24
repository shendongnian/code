	var CarsRules = new Dictionary<FuelTypes, Func<List<Car>, IEnumerable<Car>>>()
	{
		{ FuelTypes.Electric, cs => cs.Where(c => c.IsElectric) },
		{ FuelTypes.Diesel, cs => cs.Where(c => c.FuelType == FuelTypes.Diesel) },
		{ FuelTypes.Gassoline, cs => cs.Where(c => c.FuelType == FuelTypes.Gassoline) },
	}
	
	List<Car> cars = new List<Car>()
	{
		new Car(Guid.NewGuid(), "Tesla", true, FuelTypes.Electric),
		new Car(Guid.NewGuid(), "VW", false, FuelTypes.Gassoline),
		new Car(Guid.NewGuid(), "Toyota", false, FuelTypes.Gassoline),
		new Car(Guid.NewGuid(), "Volvo", false, FuelTypes.Diesel),
	};
	Console.WriteLine($"Electric: {CarsRules[FuelTypes.Electric](cars).Count()}");
	Console.WriteLine($"Gassoline: {CarsRules[FuelTypes.Gassoline](cars).Count()}");
	Console.WriteLine($"Diesel: {CarsRules[FuelTypes.Diesel](cars).Count()}");
	Console.WriteLine($"Gassoline & Diesel: {CarsRules[FuelTypes.Gassoline](cars).Union(CarsRules[FuelTypes.Diesel](cars)).Count()}");
