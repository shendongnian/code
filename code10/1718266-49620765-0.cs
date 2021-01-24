    using System;
	using System.Linq;
	using System.Collections.Generic;
	
	public class Room
	{
		public string Name { get; set; }
	}
						
	public class Program
	{
		public static void Main()
		{
			var roomDictionary = new Dictionary<Guid,Room>
			{
				{ Guid.NewGuid(), new Room { Name = "Room A" } },
				{ Guid.NewGuid(), new Room { Name = "Room B" } },
				{ Guid.NewGuid(), new Room { Name = "Room C" } },
				{ Guid.NewGuid(), new Room { Name = "Room D" } }
			};
			
            //This is the magic line
			var results = roomDictionary.ToDictionary
            ( 
                pair => pair.Key,          //Keep existing key
                pair => pair.Value.Name    //Substitute Name property instead of the Room itself
            );
			
			foreach (var pair in results)
			{
				Console.WriteLine("{0}={1}", pair.Key, pair.Value);
			}
		}
	}
	
