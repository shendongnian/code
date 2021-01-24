	public static void Main()
	{
		var errors = new ValidationErrors {
			Message = "The request is invalid.",
			ModelState = new ModelState {
				{ "", new List<string>(){"Some messege is being displayed"} }	
			}
		};
		
		var json = JsonConvert.SerializeObject(errors);
		
		Console.WriteLine(json);
	}
