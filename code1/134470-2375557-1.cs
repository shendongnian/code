    // This is a new namespace in .NET 2.0
    // that contains the SerialPort class 
    using System.IO.Ports; 
    
    private static void SendSampleData() { 
    	// Instantiate the communications
    	// port with some basic settings 
    	SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One); 
    	
    	// Open the port for 
    	communications port.Open(); 
    	
    	// Write a string 
    	port.Write("Hello World"); 
    	
    	// Write a set of bytes 
        port.Write(new byte[] {0x0A, 0xE2, 0xFF}, 0, 3); 
    	
    	// Close the port 
    	port.Close();
    }
