    public static class ControlFactory
    {
    	public static T CreateControl<T>() where T : Type, new()
    	{
    		return new T();
    	}
    }
