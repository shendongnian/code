    interface Vehicle<in TParam> where TParam : BaseParam
    {
    	IEnumerable<BaseOutput> Run(IEnumerable<TParam> parameters,
    								object anotherVal);
    }
    
    //Implementation
    class Car : Vehicle<CarParam>
    {
    	public IEnumerable<BaseOutput> Run(IEnumerable<CarParam> parameters, object anotherVal)
    	{
    		//Do something specific to the Car
    	}
    }
    
    class AirPlane : Vehicle<AirPlaneParam>
    {
    	public IEnumerable<BaseOutput> Run(IEnumerable<AirPlaneParam> parameters, object anotherVal)
    	{
    		//Do something specific to the AirPlane
    	}
    }
