    public override object ProvideValue(IServiceProvider serviceProvider)
    {
    	//Get the target control
    	var pvt = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
    	if (pvt == null) { return null; }
    	var target = pvt.TargetObject as FrameworkElement;
    	
    	//If null then return the class to bind at runtime.
    	if (target == null) { return this; }
    
    	if (target.DataContext.GetType().IsEnum)
    	{
    			Array enumValues = Enum.GetValues(target.DataContext.GetType());
    			return enumValues;                
    	}
    	return null;
    }
