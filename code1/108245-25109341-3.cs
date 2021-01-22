    public enum ModesOfTransport
    {
        [Display(Name = "Driving",	  Description = "Driving a car")] 		 Land,
        [Display(Name = "Flying", 	  Description = "Flying on a plane")]    Air,
        [Display(Name = "Sea cruise", Description = "Cruising on a dinghy")] Sea
    }
	void Main()
	{
		ModesOfTransport TransportMode = ModesOfTransport.Sea;
		DisplayAttribute metadata = TransportMode.GetDisplayAttributesFrom(typeof(ModesOfTransport));
		Tuple<string, string> tuple = new Tuple<string, string>(metadata.Name, metadata.Description);
		Console.WriteLine("Name: {0} \nDescription: {1}", tuple.Item1, tuple.Item2);
	}
