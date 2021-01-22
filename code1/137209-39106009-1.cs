    public class Stuff
    {
	    public int X;
	    public int Y;
    }
    //...
    var stuffs = new List<Stuff>()
	{
		new Stuff { X = 1, Y = 10 }, 
		new Stuff { X = 1, Y = 10 }
	};
    var sums = stuffs.Sum(s => s.X, s => s.Y);
