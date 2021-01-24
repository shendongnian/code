    class CustomFields
    {
    	public Dictionary<string, string> VehicleOptions { get; set; } = new Dictionary<string, string>();
    }
    
    var custom_fields = new CustomFields();
    foreach (Option option in options_list)
    {
    	custom_fields.VehicleOptions.Add(option.name.Value, "default value"); //Option name is a string
    }
