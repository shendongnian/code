    public static class CarFactory
    {
    	public static ImmutableCar HondaCrv { 
    		get
    		{
    			return new ImmutableCar("Honda", "Crv");
    		}
    	}
    	
    	public static Car GenerateCar(string Manufacturer, string CarModel)
    	{
    		return new Car(Manufacturer, CarModel);
    	}
    }
