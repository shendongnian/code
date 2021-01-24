    public float flySpeed = 20f;
    private Rigidbody2D arrowBody;
    private bool shouldFly;
    // Start is called before the first frame update
    void Start()
    {
        shouldFly = true;
        arrowBody = GetComponent<Rigidbody2D>();
        arrowBody.isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldFly == true)
        {         
            //make our pin fly
            arrowBody.MovePosition(arrowBody.position + Vector2.up * flySpeed * Time.deltaTime);
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
