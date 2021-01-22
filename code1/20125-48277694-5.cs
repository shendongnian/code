    using SharedPartialCodeTryout.DataTypes;
    using System;
    
    namespace SharedPartialCodeTryout.Client
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			// Create an Address
    			Address op = new Address("Kasper", 5297879, Address.Direction.NORTH);
    			// Use it
    			Console.WriteLine($"Addr: ({op.Name}, {op.Number}, {op.Dir}");
    		}
    	}
    }
