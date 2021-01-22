    public sealed class ImageListManager
    {
    	private static volatile ImageListManager instance;
    	private static object syncRoot = new object();
    	private ImageList imageList;
    
    	private ImageListManager()
    	{
    		this.imageList = new ImageList();
    		this.imageList.ColorDepth = ColorDepth.Depth32Bit;
    		this.imageList.TransparentColor = Color.Magenta;
    	}
    
    	/// <summary>
    	/// Gets the <see cref="System.Windows.Forms.ImageList"/>.
    	/// </summary>
    	public ImageList ImageList
    	{
    		get
    		{
    			return this.imageList;
    		}
    	}
    
    	/// <summary>
    	/// Gets the current instance of the 
    	/// <see cref="ImageListManager"/>.
    	/// </summary>
    	public static ImageListManager Instance
    	{
    		get
    		{
    			if (instance == null)
    			{
    				lock (syncRoot)
    				{
    					if (instance == null)
    					{
    						instance = new ImageListManager();
    					}
    				}
    			}
    			return instance;
    		}
    	}
    }
