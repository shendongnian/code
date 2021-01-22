    public class DataElementBag
    {
    	private IDictionary<Type, List<object>> _elements;
    	...
    	public void Add<T>(IDataElement<T> de)
    	{
    		Type t = typeof(T);
    		if(!this._elements.ContainsKey(t))
    		{
    			this._elements[t] = new List<object>();
    		}
    		
    		this._elements[t].Add(de);
    	}
    	
    	public void IEnumerable<IDataElement<T>> GetElementsByType<T>()
    	{
    		return this._elements[typeof(T)].Cast<IDataElement<T>>();
    	}
    }
