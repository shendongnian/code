	float Miles, Gallons, MPG;
    string textline;
    Console.Write("Miles Traveled :");
    textline = Console.ReadLine();
	Miles = float.Parse(textline); //Store to variable
    Console.Write("Gallons of Gas Used :");
    textline = Console.ReadLine();        
    Gallons = float.Parse(textline); //Store to variable
	
	
    MPG = Miles / Gallons;
    Console.Write("Miles Per Gallon :  ");
    Console.WriteLine(MPG.ToString());
    Console.ReadLine();
