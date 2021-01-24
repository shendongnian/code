    static void Main(string[] args)
    		{
    
    			Car myCar = new Car();
    			myCar.Make = "Ford";
    			myCar.Model = "Something";
    			myCar.Year = 2010;
    			myCar.Colour = "Blue";
    
    			Console.WriteLine(myCar.Stats());
    			Console.ReadKey();
    
    		}
    
    
    		public class Car
    		{
    			public string Make { get; set; }
    			public string Model { get; set; }
    			public int Year { get; set; }
    			public string Colour { get; set; }
    
    			public  string Stats()
    			{
    				string restart = "false";
    				do
    				{
    					restart = "false";
    					Console.WriteLine("Press a to get the Make of the car");
    					Console.WriteLine("Press s to get the Model of the car");
    					Console.WriteLine("Press d to get the Year of the car");
    					Console.WriteLine("Press f to get the Colour of the car");
    				}
    				while (restart == "true");
    				string UserInput = Console.ReadLine();
    
    				if (UserInput == "a")
    				{
    					string UserOutput = Make;
    					return UserOutput;
    				}
    				if (UserInput == "s")
    				{
    					string UserOutput = Model;
    					return UserOutput;
    				}
    				if (UserInput == "d")
    				{
    					string UserOutput = Year.ToString();
    					return UserOutput;
    				}
    				if (UserInput == "f")
    				{
    					string UserOutput = Colour;
    					return UserOutput;
    				}
    				else
    				{
    					restart = "true";
    					string UserOutput = "I did not understand that";
    					return UserOutput;
    				}
    			}
    		}
