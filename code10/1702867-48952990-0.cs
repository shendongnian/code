    class LevelContext
    {
    	private int _level;
    	public int CurrentLevel
    	{
    		get { return _level; }
    		set { _level = value < 0 ? 0 : value; }
    	}
    	public ILevel NewLevel(int depth = 1)
    	{
    		return new Level(this, depth);
    	}
    
    	/// <summary>
    	/// Provides an interface that calling code can use to handle level objects.
    	/// </summary>
    	public interface ILevel : IDisposable
    	{
    		LevelContext Owner { get; }
    		int Depth { get; }
    		void Close();
    	}
    
    	/// <summary>
    	/// Private class that provides an easy way to scope levels by allowing
    	/// them to participate in the "using" construct. Creation of a Level results in an
    	/// increase in owner's level, while disposal returns owner's level to what it was before.
    	/// </summary>
    	class Level : ILevel
    	{
    		public Level(LevelContext owner, int depth)
    		{
    			Owner = owner;
    			Depth = depth;
    			PreviousLevel = owner.CurrentLevel;
    			Owner.CurrentLevel += Depth;
    		}
    
    		public LevelContext Owner { get; private set; }
    		public int Depth { get; private set; }
    		public int PreviousLevel { get; private set; }
    
    		public void Close()
    		{
    			if (Owner != null)
    			{
    				Owner.CurrentLevel = PreviousLevel;
    				Owner = null;
    			}
    		}
    
    		void IDisposable.Dispose()
    		{
    			Close();
    		}
    
    	}
