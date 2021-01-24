    public class PlatformScript : MonoBehaviour
    {
    	public float jumpForce = 10f;
    
    	void OnCollisionEnter2D (Collision2D collision)
    	{
    		if (collision.relativeVelocity.y <= 0)
    		{
    			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
    
    			if (rb != null)
    			{
    				Vector2 velocity = rb.velocity;
    				velocity.y = jumpForce;
    				rb.velocity = velocity;
    			}
                // update our global score
    			LevelGenerator.currentScore += 10;
    			Destroy(gameObject);
    		}
    	}
    }
    public class LevelGenerator : MonoBehaviour
    {
    	// global persistent data
    	public static int currentScore;
    
    	public Text displayScore;
    	public GameObject platformPrefab;
    
    	public int numberOfPlatforms = 200;
    	public float levelWidth = 3f;
    	public float minY = 1f;
    	public float maxY = 3.2f;
    
    	void Start ()
    	{
    		Vector3 spawnPosition = new Vector3();
    		for (int i = 0; i < numberOfPlatforms; i++)
    		{
    			spawnPosition.y += Random.Range(minY, maxY);
    			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
    			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    		}
    	}
    
    	void Update ()
    	{
    		displayScore.text = "Score: " + currentScore;
    	}
    }
