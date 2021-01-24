        using System;
    					
        public class Program
       {
    	public static void Main()
    	{
    		
    		
      		HDDFormat disk = new HDDFormat();
    		
    		disk.TotalSpace = "500gb";
    		disk.SpaceLeft = "120gb";
    		disk.PercentageLeft = "60%";
    		disk.Timestamp = "2018-10-11 ";
    
    		Console.WriteLine(disk.HDDformat());
      
    	   }
         }
    
         public class HDDFormat
         {
          public string TotalSpace { get; set; }
          public string SpaceLeft { get; set; }
          public string PercentageLeft { get; set; }
          public string Timestamp { get; set; }
    	
         public string HDDformat(){
     	  return TotalSpace + SpaceLeft + PercentageLeft + Timestamp; }
          }
