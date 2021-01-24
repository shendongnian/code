    public class Hero : IGameObject
    {
    	private Texture2D texture;
    	private Vector2 position;
    	private Color color;
    	
    	public Hero(string path)
    	{
    		texture = GameUtility.Instance.ContentManager.Load<Texture2D>(path);
    	}
    	
    	public void Update(GameTime gameTime)
    	{
    		// Do game update logic
    	}
    	
    	public void Draw()
    	{
    		GameUtility.Instance.SpriteBatch.Begin();
    		
    		GameUtility.Instance.SpriteBatch.Draw(texture, position, color);
    		
    		GameUtility.Instance.SpriteBatch.End();
    	}
    }
