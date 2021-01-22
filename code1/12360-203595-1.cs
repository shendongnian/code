     public static void Main(string[] args) 
     {
    	 // test case 1 0xFC, 0xD1
    	 var bytes = new byte[] { 0x0F, 0xAA, 0xFF };
    	 var crc = CrcB.ComputeCrc(bytes);
    	 var cbytes = BitConverter.GetBytes(crc);
    
    	 Console.WriteLine("First (0xFC): {0}\tSecond (0xD1): {1}", cbytes[0], cbytes[1]);
    
    	 // test case 2 0xCC, 0xC6
    	 bytes = new byte[] { 0x00, 0x00, 0x00 };
    	 crc = CrcB.ComputeCrc(bytes);
    	 cbytes = BitConverter.GetBytes(crc);
    	 Console.WriteLine("First (0xCC): {0}\tSecond (0xC6): {1}", cbytes[0], cbytes[1]);
    
    
    	 Console.ReadLine();
    }
