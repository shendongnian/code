    using System;
    using System.Diagnostics;
    using System.Linq;
    using ExtensionMethods;
    
    namespace ConsoleApp1
    {
    
    	class Program
    	{
    
    		static void Main(string[] args)
    		{
    			// test data...
    			string s = string.Join(";", Enumerable.Range(65, 26).Select(c => (char)c));
    			s = s.Insert(3, ";;;");
    
    			string o = "";
    
    			Stopwatch sw = new Stopwatch();
    
    			sw.Start();
    			for (int i = 1; i <= 1000000; i++) {
    				o = s.Split(';', 21);
    			}
    			sw.Stop();
    			Console.WriteLine("Item directly selected: " + sw.ElapsedMilliseconds);
    
    			sw.Restart();
    			for (int i = 1; i <= 1000000; i++) {
    				o = s.Split(';')[21];
    			}
    			sw.Stop();
    			Console.WriteLine("Item from split array:  " + sw.ElapsedMilliseconds + "\r\n");
    			
    
    			Console.WriteLine(s);
    			Console.WriteLine(o);
    
    			Console.ReadLine();
    
    		}
    	}
    }
    
