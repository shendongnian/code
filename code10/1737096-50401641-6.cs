    public class DUnion<T1, T2>
    {
    	public DUnion(T1 t1) 
    	{ 
    		Type1Item = t1;
    		Type2Item = default(T2);
    		IsType1 = true;
    	}
    	
    	public DUnion(T2 t2) 
    	{ 
    		Type2Item = t2;
    		Type1Item = default(T1);
    		IsType1 = false;
    	}
    
    	public bool IsType1 { get; }
    	public bool IsType2 => !IsType1;
    
    	public T1 Type1Item { get; }
    	public T2 Type2Item { get; }
    }
