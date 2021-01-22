    private static Func<T, DictionaryEntry> GetNameValuePairFunc<T>(string valueField, string textField)
    {
    	Func<T, DictionaryEntry> result = (item) =>
    	{
    		object key = typeof(T).GetProperty(valueField).GetValue(item, null);
    
    		object text = typeof(T).GetProperty(textField).GetValue(item, null);
    
    		return new DictionaryEntry(key, text);
    	};
    
    	return result;
    }
