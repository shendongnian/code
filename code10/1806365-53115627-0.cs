    public class shooter : MonoBehaviour {
    	public GameObject powercell;	//link to the powerCell prefab
    	public int no_cell ;			//number of powerCell owned
    	public AudioClip throwSound;	//throw sound
    	public float throwSpeed = 20;	//throw speed
    	
    	// Use this for initialization
    	void Start(){
    		no_cell = 1;
    	}
    	
    	// Update is called once per frame
    	public void Update()
    	{
    		//if left control (fire1) pressed, and we still have at least 1 cell
    		if (Input.GetButtonDown("Fire1") && no_cell > 0)
    		{
    			no_cell--; //reduce the cell
    					   //play throw sound
    			AudioSource.PlayClipAtPoint(throwSound, transform.position);
    			//instantaite the power cel as game object
    			GameObject cell = Instantiate(powercell, transform.position,
    			transform.rotation) as GameObject;
    			//ask physics engine to ignore collison between
    			//power cell and our FPSControler
    			Physics.IgnoreCollision(transform.root.GetComponent<Collider>(),
    			cell.GetComponent<Collider>(), true);
    			//give the powerCell a velocity so that it moves forward
    			cell.GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;
    		}
    	}
    
    	
    	void OnTriggerEnter(Collider other)
    	{
    		if (other.gameObject.tag == "Item")
    		{
    			no_cell++;    			
    			Debug.Log("Number of cells:"+no_cell.ToString());
    			Destroy(other);
    		}
    	}
    
    	
    }
            
