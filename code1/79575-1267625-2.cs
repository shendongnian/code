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
         /// Adds an image with the specified key to the end of the collection if it 
         /// doesn't already exist.
         /// </summary>
         public void AddImage(string imageKey, Image image)
         {
            if (!this.imageList.ContainsKey(imageKey))
            {
               this.imageList.Add(imageKey, image);
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
