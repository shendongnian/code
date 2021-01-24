    public class Timer : MonoBehaviour
    {
        public Collide _collide;
        Text instruction;
    	
    	int _timeLeft;
    	
        void Start()
        {
            instruction = GetComponent<Text>();
    		InitializeTimeLeft();
            InvokeRepeating("time", 0, 1);
        }
    
    	void InitializeTimeLeft()
    	{
    	    if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                _timeLeft = 120;
    		}
            else
            {
                _timeLeft = 90;
            }
    	}
    
        void time()
        {
           ...
        }
    }
