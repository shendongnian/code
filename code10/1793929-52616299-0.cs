    static void Main(string[] args)
        {
            Operator operatorObject = new Operator();
            Console.WriteLine("Pick a number:");
    		var val1=Console.ReadLine();
            int userValue = 0;
    		if (val1!=null &&val1.Length>0)
    		{	
    			userValue=Convert.ToInt32(Console.ReadLine());
    		}
            Console.WriteLine("Pick another number--optional");
            var val1=Console.ReadLine();
            int userValue = 0;
    		int userValue2 = 0;
    		if (val1!=null &&val1.Length>0)
    		{	
    			userValue2=Convert.ToInt32(Console.ReadLine());
    		}
    		
    
            int result = operatorObject.operate(userValue, userValue2);
    
            Console.WriteLine(result);
            Console.ReadLine();
        }
