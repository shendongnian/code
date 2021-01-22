    public class ControlFactory
    {
    	public T CreateControl<T>() where T : Control, new()
    	{
    		return new T();
    	}
    }
