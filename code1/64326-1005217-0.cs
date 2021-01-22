    public class GuessingGame
    {
    	private static Random _RNG = new Random();
    	private bool _GameRunning;
    	private bool _GameWon;
    	private int _Number;
    	private int _GuessesRemaining;
    
    	public int GuessesRemaining
    	{
    		get { return _GuessesRemaining; }
    	}
    
    	public bool GameEnded
    	{
    		get { return !_GameRunning; }
    	}
    
    	public bool GameWon
    	{
    		get { return _GameWon; }
    	}
    
    	public GuessingGame()
    	{
    		_GameRunning = false;
    		_GameWon = false;
    	}
    
    	public void StartNewGame(int numberOfGuesses, int max)
    	{
    		if (max <= 0)
    			throw new ArgumentOutOfRangeException("max", "Must be > 0");
    
    		if (max == int.MaxValue)
    			_Number = _RNG.Next();
    		else
    			_Number = _RNG.Next(0, max + 1);
    		
    		_GuessesRemaining = numberOfGuesses;
    		_GameRunning = true;
    	}
    
    	public bool MakeGuess(int guess)
    	{
    		if (_GameRunning)
    		{
    			_GuessesRemaining--;
    			if (_GuessesRemaining <= 0)
    			{
    				_GameRunning = false;
    				_GameWon = false;
    				return false;
    			}
    
    			if (guess == _Number)
    			{
    				_GameWon = true;
    				return true;
    			}
    			else
    			{
    				return false;
    			}
    		}
    		else
    		{
    			throw new Exception("The game is not running. Call StartNewGame() before making a guess.");
    		}
    	}
    }
