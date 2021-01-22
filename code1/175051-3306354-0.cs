    public class Matrix<T>
    {
    	private int size;
    	private T[] elements;
    
    	public Matrix(int size)
    	{
    		this.size = size;
    		this.elements = new T[size];
    	}
    
    	T this[int x, int y]
    	{
    		get
    		{
    			return elements[x + (y*size)];
    		}
    		set
    		{
    			elements[x + (y*size)] = value;
    		}
    	}
    
    	public void CopyTo(Matrix<T> destination, int x, int y)
    	{
    		int offset = x + (y*size);
    		T[] destinationArray = (T[])destination;
    		Buffer.BlockCopy(this.elements, 0, destinationArray, offset, this.elements.Length);
    	}
    
    	public static explicit operator T[] (Matrix<T> matrix)
    	{
    		return matrix.elements;
    	}
    }
