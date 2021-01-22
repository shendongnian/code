    namespace WpfApplication1
    {
    	public class DebugReleaseStylePicker
    	{
    		#if DEBUG
    				internal static readonly bool debug = true;
    		#else
    		internal static readonly bool debug=false;
    		#endif
    
    		public Style ReleaseStyle
    		{
    			get; set;
    		}
    
    		public Style DebugStyle
    		{
    			get; set;
    		}
    
    
    		public Style CurrentStyle
    		{
    			get
    			{
    				return debug ? DebugStyle : ReleaseStyle;
    			}
    		}
    	}
    }
