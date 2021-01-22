    class Permutations<T1, T2> : IEnumerable<Tuple<int, T1, T2>>
        where T1 : struct
        where T2 : struct
    {
    	int countT1 = 0;
    	int countT2 = 0;
    	
    	public Permutations()
    	{
    		countT1 = Enum.GetValues(typeof(T1)).Length;
    		countT2 = Enum.GetValues(typeof(T2)).Length;		
    	}
    	
    	public int Length
    	{
    		get {
    			return countT1 * countT2;
    		}
    	}
    	
    	public Tuple<int, T1, T2> this[int index]
    	{
    		get {					
    			return new Tuple<int, T1, T2>(
    					   index,
    			/*Hack ->*/(T1)(object)((index - 1) / countT1),
    			/*Hack ->*/(T2)(object)((index - 1) % countT2));
    		}
    	}
    	
    	public IEnumerator<Tuple<int, T1, T2>> GetEnumerator()
    	{
    		return Enumerable.Range(1, this.Length).Select (i => this[i]).GetEnumerator();
    	}
    	
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return this.GetEnumerator();
    	}
    }
    
    void Main()
    {		
    	var permutations = new Permutations<Color, Vehicle>();
    	// Can be accesed individually:
    	var permutation = permutations[1];
    	// Can be accesed using Enumerations
    	permutations.Dump(); // LINQPad Dump
    }
