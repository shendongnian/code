    [assembly: ExportRenderer(typeof(ModernLogin), typeof(ModernLoginPageRenderer))]
    namespace MyApp.Droid.Renderer
    {
    	public class ModernLoginPageRenderer : PageRenderer
    	{
    		public ModernLoginPageRenderer(Context context) : base(context)
    		{
    		}
    		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
    		{
    			base.OnElementChanged(e);
    			// Deactivate SoftInput View Adjustment for this window
    			if (e.NewElement != null)
	    		{
	    			(this.Context as FormsApplicationActivity).Window.SetSoftInputMode(SoftInput.AdjustResize);				
	    		}
	    	}
	    	protected override void OnWindowVisibilityChanged([GeneratedEnum] ViewStates visibility)
	    	{
		    	// Enable SoftInput View Adjustment after moving away from this window
			    if (visibility == ViewStates.Gone)
		    	{
		    		(this.Context as FormsApplicationActivity).Window.SetSoftInputMode(SoftInput.AdjustPan);
		    	}
		    	base.OnWindowVisibilityChanged(visibility);
		    }
		    protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
		    {
		    	base.OnLayout(changed, left, top, right, bottom);
		    }
	    }
    }
