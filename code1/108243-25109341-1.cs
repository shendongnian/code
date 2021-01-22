    public enum ModesOfTransport
    {
        [Display(Name = "Driving",	  Description = "Driving a car")] 		 Land,
        [Display(Name = "Flying", 	  Description = "Flying on a plane")]    Air,
        [Display(Name = "Sea cruise", Description = "Cruising on a dinghy")] Sea
    }
	void Main()
	{
		ModesOfTransport Transport= ModesOfTransport.Sea;
		
		Tuple<string, string> transportMetadata = Transport.GetDisplayAttributesFrom(typeof(ModesOfTransport));
		Console.WriteLine("Name: {0} \nDescription: {1}", transportMetadata.Item1, transportMetadata.Item2);
	}
