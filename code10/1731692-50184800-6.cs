	var baseParameters = new List<BaseParam>();
	var airPlaneParameters = new List<AirPlaneParam>();
	var vehicles = new List<Vehicle>();
	
	foreach (Vehicle vehicle in vehicles)
	{
		vehicle.Run(baseParameters, "Foo");      //Works, although only airplane parameters will get processed
		vehicle.Run(airPlaneParameters, "Foo");  //Works, due to generic covariance
	}
	
	foreach (AirPlane airplane in vehicles.OfType<AirPlane>())
	{
		airplane.Run(baseParameters, "Foo"); //Does not compile
		airplane.Run(airPlaneParameters, "Foo"); //Works
	}
