    public sealed class GameUtility
    {
    	private static GameUtility instance = null;
        private static readonly object _lock = new object();
    	
    	public ContentManager ContentManager { get; private set; }
    	
    	public SpriteBatch SpriteBatch { get; private set; }
    	
    	public static GameUtility Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new GameUtility();
                    }
    				
                    return instance;
                }
            }
        }
    	
    	public void SetContentManager(ContentManager contentManager)
    	{
    		this.ContentManager = contentManager;
    	}
    	
    	public void SetSpriteBatch(SpriteBatch spriteBatch)
    	{
    		this.SpriteBatch = spriteBatch;
    	}
    	
    	public GameUtility(ContentManager contentManager, SpriteBatch spriteBatch)
    	{
    		this.contentManager = contentManager;
    		this.spriteBatch = spriteBatch;
    	}
    }
