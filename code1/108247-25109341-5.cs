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
		Console.WriteLine("Name: {0} \nDescription: {1}", metadata.Name, metadata.Description);
	}
