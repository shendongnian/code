    [assembly: Dependency(typeof(ScreenDimensions))]
    namespace MyAppNamespace.Droid
    {
    	public class ScreenDimensions : IScreenDimensions
	    {
		    public double GetScreenHeight()
		    {
			    return ((double)Android.App.Application.Context.Resources.DisplayMetrics.HeightPixels / (double)Android.App.Application.Context.Resources.DisplayMetrics.Density);
		    }
		    public double GetScreenWidth()
		    {
			    return ((double)Android.App.Application.Context.Resources.DisplayMetrics.WidthPixels / (double)Android.App.Application.Context.Resources.DisplayMetrics.Density);
		    }
	    }
    }
