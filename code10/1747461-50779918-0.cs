            string[] aNames = new string[10] { "Ronaldo", "Messi", "Aguero", "Dembele", "Reus", "Mbappe", "Sane", "Sterling", "Ibrahimovic", "Alaba" };
            Random rd = new Random();
            int randomIndex = rd.Next(0, aNames.Length);
            Console.WriteLine("Enter the First Name of "+aNames[randomIndex]);
		    String FirstName = Console.ReadLine();
		    Console.WriteLine("You Entered : "+FirstName);//User input is stored in FirstName apply your logic here
