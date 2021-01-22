    public class Range<T> where T : IComparable
    {
    	public T InferiorBoundary{get;private set;}
    	public T SuperiorBoundary{get;private set;}
    
    	public Range(T inferiorBoundary, T superiorBoundary)
        {
       	    InferiorBoundary = inferiorBoundary;
        	SuperiorBoundary = superiorBoundary;
        }
    
    	public bool IsWithinBoundaries(T value){
    		return InferiorBoundary.CompareTo(value) > 0 && SuperiorBoundary.CompareTo(value) < 0;
        }
    }
