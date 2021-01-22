			public string name;
			public int inhabitansNumber;
		}
    Cities[] cities = new Cities[500]; // the struct array holding the cities
    
    int i = 0;
    					for (i = 0; i < cities.Length; ++i)
    					{
    						if (cities[i].Equals(default(Cities)))
    						{
    							Console.WriteLine("Please enter the city name:");
    							cities[i].name = Console.ReadLine();
    							Console.WriteLine("Please enter population:");
    							cities[i].inhabitansNumber = Convert.ToInt32(Console.ReadLine());
    							Console.WriteLine("Values added successfuly!");
    						}
    					}
