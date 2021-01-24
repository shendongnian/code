    Type t = Type.GetType("System.Int32");
	
    Console.WriteLine("Sizeof: " + System.Runtime.InteropServices.Marshal.SizeOf(y));	
    Console.WriteLine("Type: " + t);
		
    var x = Activator.CreateInstance(t);
				
    Console.WriteLine("Value: " + x);
