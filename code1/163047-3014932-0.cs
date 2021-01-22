    public static class DictionaryExtensions
    {
    	public static DictionaryChecker<TKey,TValue> contains<TKey,TValue>(this IDictionary<TKey,TValue> dictionary, TValue value)
    	{
    		return new DictionaryChecker<TKey,TValue>(value, dictionary);
    	}
    }
    
    public class DictionaryChecker<TKey,TValue>
    {
    	TValue value;
    	IDictionary<TKey,TValue> dictionary;
    
    	internal DictionaryChecker(TValue value, IDictionary<TKey, TValue> dictionary)
    	{
    		this.value = value;
    		this.dictionary = dictionary;
    	}
    
    	public bool For(TKey key)
    	{
    		TValue result;
    		return dictionary.TryGetValue(key, out result) && result.Equals(value);
    	}
    }
