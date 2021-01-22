    //Generic Game Class
    public class MySweetGame : Game
    {
    	Player _player = new Player(this);
    	List<Bullet> _bullets = new List<Bullet>();
    	public List<Bullet> AllBullets()
    	{
    		get { return _bullets; }
    	}
    	
    	
    	public void Update()
    	{
    		//You would obviously need some keyboard/mouse class to determine if a click took place
    		if(leftMouseButtonClicked)
    		{
    			_player.Shoot();
    		}
    		
    		//This would be assuming you have an object collection or array to hold all the bullets currently 'live' like the above '_bullets' collection
    		//This is also assuming elapseGameTime is some built in game time management, like in XNA
    		foreach(Bullet blt in _bullets)
    		{
    			blt.Update(elapsedGameTime);
    		}
    	}
    }
    
    //Generic Player Class
    public class Player()
    {
    	Vector2 _position = new Vector2(0,0);
    	int _ammunition = 50;
    	MySweetGame _game;
    	
    	public Player(MySweetGame game)
    	{
    		_game = game;
    	}
    	
    	public void Shoot()
    	{
    		if(_ammunition > 0){
    			_game.AllBullets.Add(new Bullet(50, _position));
    			_ammunition--;
    		}
    	}
    }
    
    //Generic Bullet Class
    public class Bullet()
    {
    	float _metersPerSecond = 0;
    	Vector2 _position = new Vector2(0, 0);
    	
    	public Bullet(float metersPerSecond, Vector3 position)
    	{
    		_metersPerSecond = metersPerSecond;
    		_position = position;
    	}
    	
    	//Here is the meat you wanted
    	//We know the speed of the bullet, based on metersPerSecond - which we set when we instantiated this object
    	//We also know the elapsedGameTime since we last called update
    	//So if only .25 seconds have passed - we only moved (50 * .25) - and then update our position vector
    	public void Update(float elapsedGameTime)
    	{
    		distanceTraveled = metersPerSecond * elapsedGameTime;
    		_position.x += distanceTraveled;
    	}
    }
