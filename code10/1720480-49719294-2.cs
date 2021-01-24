    public float speed = 10.0f;
    public int damage = 1;
    [SerializeField]
    private GameObject wallHit;
    private GameObject _wallHit;
    
    public Rigidbody rb;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Move to towards Z-axis
        Vector3 pos = new Vector3(0, 0, 1);
        pos = pos.normalized * speed * Time.deltaTime;
    
        rb.MovePosition(rb.transform.position + pos);
    }
    void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        ReactiveTarget target = other.GetComponent<ReactiveTarget>();
        WallBehavior wall = other.GetComponent<WallBehavior>();
    
        if (player != null)
        {
            player.Hurt(damage);
        }
        if (target != null)
        {
            target.ReactToHit();
        }
        if (wall != null)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                wall.WallWasHit(hit);
            }
        }
        Destroy(this.gameObject);
    }
