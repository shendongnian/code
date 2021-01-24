    [assembly: Dependency(typeof(ScreenDimensions))]
    namespace MyAppNamespace.iOS
    {
    	public class ScreenDimensions : IScreenDimensions
	    {
		    public double GetScreenHeight()
		    {
			    return (double)UIScreen.MainScreen.Bounds.Height;
		    }
		    public double GetScreenWidth()
		    {
			    return (double)UIScreen.MainScreen.Bounds.Width;
		    }
	    }
    }
