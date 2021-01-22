    using System;
    
    namespace Testing
    {
    	class C1 : IDisposable
    	{
    		public C1()
    		{
    		}
    		public void Dispose()
    		{
    			Console.WriteLine( "C1 Destroyed" );
    		}
    	}
    	class C2 : IDisposable
    	{
    		public C2()
    		{
    			throw new Exception();
    		}
    		public void Dispose()
    		{
    			Console.WriteLine( "C2 Destroyed" );
    		}
    	}
    	class C3 : IDisposable
    	{
    		C1 c1;
    		C2 c2;
    		public C3()
    		{
    			try {
    				c1 = new C1();
    				c2 = new C2();
    			} catch {
    				throw new Exception();
    			}
    		}
    		~C3()
    		{
    			this.Dispose();
    			
    		}
    		public void Dispose()
    		{
    			// basically an early deconstructor
    			Console.WriteLine( "C3 Being Destroyed" );
    			if ( c1 != null )
    				c1.Dispose();
    			if ( c2 != null )
    				c2.Dispose();
    			GC.SuppressFinalize(this);
    			Console.WriteLine( "C3 Destroyed" );
    		}
    	}
    	class MainClass
    	{
    		public static void Main(string[] args)
    		{
    			try {
    				using ( var c3 = new C3() )
    				{
    					Console.WriteLine("Rawr");
    				}
    			} catch {
    				Console.WriteLine( "C3 Failed" );
    			}
    			GC.Collect();
    		}
    	}
    }
