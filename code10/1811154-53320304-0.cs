	void Main()
	{
		var controls = Enumerable.Range(1,100).Select(i => new Control()).ToArray(); //create an Control[] with 100 controls.
		var colors = new[] {"Red", "Blue", "Green", "Yellow"}; //create a string[] holding your various color values
		
		//assign a color to each control
		for (int i=0; i<controls.Length; i++)
		{
			controls[i].Color = colors[i % colors.Length];
		}
		
		//show the result
		foreach (var control in controls)
		{
			Console.WriteLine(control.Color);
		}
	}
	
	class Control 
	{
		public string Color{get;set;}
	}
