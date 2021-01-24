    public float flySpeed = 20f;
    private Rigidbody2D arrowBody;
    private bool shouldFly;
    private Vector2 initPos;
    private Quaternion initRot;
    // Start is called before the first frame update
    void Start()
    {
        shouldFly = true;
        arrowBody = GetComponent<Rigidbody2D>();
        //arrowBody.isKinematic = true;
        initPos = gameObject.transform.position;
        initRot = gameObject.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldFly == true)
        {         
            //make our pin fly
            arrowBody.MovePosition(arrowBody.position + Vector2.up * flySpeed * Time.deltaTime);
        }
        if(gameObject.transform.parent == null)
        {
            initPos = gameObject.transform.position;
            initRot = gameObject.transform.rotation;
        }
        
    }
    void LateUpdate()
    {
        if (gameObject.transform.parent != null)
        {
            gameObject.transform.position = initPos;
            gameObject.transform.rotation = initRot;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision happened");
        if (collision.tag == "target")
        {          
            shouldFly = false;          
            transform.SetParent(collision.gameObject.transform);
        }
        else if (collision.tag == "arrow")
        {
            SceneManager.LoadScene("quickGameOverScene");
        }
    }
 
   
