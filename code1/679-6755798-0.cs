    private sealed class IntDictionary : KeyedCollection<string, int>
    {
    	protected override string GetKeyForItem(int item)
    	{
    		// The example works better when the value contains the key. It falls down a bit for a dictionary of ints.
    		return item.ToString();
    	}
    }
    
    KeyedCollection<string, int> intCollection = new ClassThatContainsSealedImplementation.IntDictionary();
		
    intCollection.Add(7);
    int valueByIndex = intCollection[0];
