    public static class Colors
    {	
    	public static readonly Color Red   = new Color(255, 0, 0);
    	public static readonly Color Green = new Color(0, 255, 0);
    	public static readonly Color Blue  = new Color(0, 0, 255);
    	
    	public static readonly Color White = new Color(255, 255, 255);
    	public static readonly Color Black = new Color(0, 0, 0);
    }
    
    public class Color
    {
    	public int R;
    	public int G;
    	public int B;
    	
    	public Color() : this(Colors.Black) {}
    	
        public Color(Color other) : this(other.R, other.G, other.B) {}
          	
    	public Color(int red, int green, int blue)
    	{
    		R = red;
    		G = blue;
    		B = blue;
    	}
    }
    
    public class Ball
    {
    	public Color SurfaceColor { get; private set; }
    	
    	public Ball(Color surfaceColor)
    	{
    		SurfaceColor = surfaceColor;
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Ball blueBall /* huh */ = new Ball(Colors.Blue);
    		Ball redBall            = new Ball(Colors.Red);
            Ball maroonBall         = new Ball(new Color(128, 0, 0));
    	}
    }
 
