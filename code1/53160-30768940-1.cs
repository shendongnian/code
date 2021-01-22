    public class ElementCollection<T> : ConfigurationElementCollection, IList<T>
    	...
    	public new IEnumerator<T> GetEnumerator()
    	{
    		var baseEnum = base.GetEnumerator();
    		while (baseEnum.MoveNext())
    		{
    			yield return baseEnum.Current as T;
    		}
    	}
    	...
    }
