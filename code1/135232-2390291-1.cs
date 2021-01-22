    public class MyClassB : MyClassA
    {
    	public String Property_Z { get; set; }
    
    	public static explicit operator MyClassB(MyClassA a)
    	{
    		MyClassB b = new MyClassB();
    		b.Property_A = a.Property_A;
    		/* ... */
    		b.Property_Y = a.Property_Y;
			return b;
    	}
    }
