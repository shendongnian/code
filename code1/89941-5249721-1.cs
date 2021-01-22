    namespace PropertyTest
    
    {
    
    	class a
    	{
    
    		int nVal;
    		public virtual int PropVal
    		{
    			get
    			{
    				return nVal;
    			}
    			set
    			{
    				nVal = value;
    			}
    		}
    	}
    
    	class b : a
    	{
    		public new int PropVal
    		{
    			get
    			{
    				return base.PropVal;
    			}
    		}
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			a objA = new a();
    			objA.PropVal = 1;
    			Console.WriteLine(objA.PropVal);
    
    			b objB = new b();
    			objB.PropVal = 10;
    
    
    			Console.Read();
    		}
    	}
    }
