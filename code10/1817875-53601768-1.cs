    public class SpawnerController : MonoBehaviour
    {
    
    	public GrannyController player;
    	public GameObject duck;
    	public Transform[] spawnSpots;
    	private float timeBtwSpawns;
    	public float startTimeBtwSpawns;
    
    	// Use this for initialization
    	void Start()
    	{
    		timeBtwSpawns = startTimeBtwSpawns;
    	}
    
    	// Update is called once per frame
    	void Update()
    	{
    		if(!player.IsAlive()) return; // Check if player is alive, stop if not
    		
    		timeBtwSpawns -= Time.deltaTime;
    
    		if (timeBtwSpawns <= 0)
    		{
    			int randPos = Random.Range(0, spawnSpots.Length);
    			Instantiate(duck, spawnSpots[randPos].position, Quaternion.identity);
    			timeBtwSpawns = startTimeBtwSpawns;
    		}
    	}
    }
