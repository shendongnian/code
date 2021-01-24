    class CustomFields
    {
    	public List<Dictionary<string, string>> vehicle_options { get; set; } = new List<Dictionary<string, string>>();
    
    	public void AddVehicleOption(string value)
    	{
    		var options = new Dictionary<string, string>();
    		options.Add("vehicle_options", value);
    		vehicle_options.Add(options);
    	}
    }
    
    var custom_fields = new CustomFields();
    foreach (Option option in options_list)
    {
    	custom_fields.AddVehicleOption(option.name.Value); //Option name is a string
    }
