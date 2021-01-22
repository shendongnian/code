    class Program{
    
       static void Main(string[] args){
    
          try{
            
    	 int i = (int)Convert.ToInt64(args[0]);
             Console.WriteLine("\n{0} converted to Binary is {1}\n",i,ToBinary(i));
          
          }catch(Exception e){
            
             Console.WriteLine("\n{0}\n",e.Message);
     
          }
    
       }//end Main
    
    
    		public static string ToBinary(Int64 Decimal)
    		{
    			// Declare a few variables we're going to need
    			Int64 BinaryHolder;
    			char[] BinaryArray;
    			string BinaryResult = "";
    
    			while (Decimal > 0)
    			{
    				BinaryHolder = Decimal % 2;
    				BinaryResult += BinaryHolder;
    				Decimal = Decimal / 2;
    			}
    
    			// The algoritm gives us the binary number in reverse order (mirrored)
    			// We store it in an array so that we can reverse it back to normal
    			BinaryArray = BinaryResult.ToCharArray();
    			Array.Reverse(BinaryArray);
    			BinaryResult = new string(BinaryArray);
    
    			return BinaryResult;
    		}
    
    
    }//end class Program
