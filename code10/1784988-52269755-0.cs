    class Coordinate
    {
    	public int Width { get; private set; }
    	public int Height { get; private set; }
    	public int X { get; private set; }
    	public int Y { get; private set; }
    
    	public Coordinate(string str)
    	{
            // Validate str and/or p and check of the TryParse was successful
    		var p = str.Split(new char[] { ';', '|' }).Select(x =>
    		{
    			int.TryParse(x, out int res);
    			return res;
    		});
    
    		Width = p.ElementAt(0);
    		Height = p.ElementAt(1);
    		X = p.ElementAt(2);
    		Y = p.ElementAt(3);
    	}
    }
    
    static class CoordinateValidator
    {
    	public static bool isValidCoordinate(Coordinate coordinate)
    	{
    		// Here add your validation Logic
    		return coordinate.Height > 0 && coordinate.Width > 0;
    	}
    }
    
    static void Main(string[] args)
    {
    	string s = "78;58|98;52";
    	Coordinate coordinate = new Coordinate(s);
    	Console.WriteLine("Is valid: " + CoordinateValidator.isValidCoordinate(coordinate));
    	Console.ReadLine();
    }
