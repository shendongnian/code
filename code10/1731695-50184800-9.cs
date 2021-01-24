	class AirPlane : Vehicle
	{
		IEnumerable<BaseOutput> Vehicle.Run(IEnumerable<BaseParam> parameters, object anotherVal)
		{
			return Run(parameters.OfType<AirPlaneParam>(), anotherVal);
		}
		public IEnumerable<BaseOutput> Run(IEnumerable<AirPlaneParam> parameters, object anotherVal)
		{
			//Your implementation
		}
	}
