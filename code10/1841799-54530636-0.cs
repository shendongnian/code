	var data = String.Join(Environment.NewLine, new[]
	{
		"Let it be",
		"Beatles",
		// ...
	});
	
	Console.SetIn(new System.IO.StringReader(data));
    // usage:
    var songName = Console.ReadLine();
    var artistName = Console.ReadLine();
