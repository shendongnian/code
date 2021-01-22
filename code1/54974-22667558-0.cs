    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    namespace ListRemoveTest
    {
    	class Program
    	{
    		private static Random random = new Random( (int)DateTime.Now.Ticks );
    
    		static void Main( string[] args )
    		{
    			Console.WriteLine( "Be patient, generating data..." );
    
    			List<string> list = new List<string>();
    			List<string> toRemove = new List<string>();
    			for( int x=0; x < 1000000; x++ )
    			{
    				string randString = RandomString( random.Next( 100 ) );
    				list.Add( randString );
    				if( random.Next( 1000 ) == 0 )
    					toRemove.Insert( 0, randString );
    			}
    
    			List<string> l1 = new List<string>( list );
    			List<string> l2 = new List<string>( list );
    			List<string> l3 = new List<string>( list );
    			List<string> l4 = new List<string>( list );
    
    			Console.WriteLine( "Be patient, testing..." );
    
    			Stopwatch sw1 = Stopwatch.StartNew();
    			l1.RemoveAll( toRemove.Contains );
    			sw1.Stop();
    
    			Stopwatch sw2 = Stopwatch.StartNew();
    			l2.RemoveAll( new HashSet<string>( toRemove ).Contains );
    			sw2.Stop();
    
    			Stopwatch sw3 = Stopwatch.StartNew();
    			l3 = l3.Except( toRemove ).ToList();
    			sw3.Stop();
    
    			Stopwatch sw4 = Stopwatch.StartNew();
    			l4 = l4.Except( new HashSet<string>( toRemove ) ).ToList();
    			sw3.Stop();
    
    
    			Console.WriteLine( "L1.Len = {0}, Time taken: {1}ms", l1.Count, sw1.Elapsed.TotalMilliseconds );
    			Console.WriteLine( "L2.Len = {0}, Time taken: {1}ms", l1.Count, sw2.Elapsed.TotalMilliseconds );
    			Console.WriteLine( "L3.Len = {0}, Time taken: {1}ms", l1.Count, sw3.Elapsed.TotalMilliseconds );
    			Console.WriteLine( "L4.Len = {0}, Time taken: {1}ms", l1.Count, sw3.Elapsed.TotalMilliseconds );
    
    			Console.ReadKey();
    		}
    
    
    		private static string RandomString( int size )
    		{
    			StringBuilder builder = new StringBuilder();
    			char ch;
    			for( int i = 0; i < size; i++ )
    			{
    				ch = Convert.ToChar( Convert.ToInt32( Math.Floor( 26 * random.NextDouble() + 65 ) ) );
    				builder.Append( ch );
    			}
    
    			return builder.ToString();
    		}
    	}
    }
