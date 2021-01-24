    bool canMove = false;
    void OnEnable()
    {
        PlayerTriggered += StartMoving;
    }
    void OnDisable()
    {
        PlayerTriggered -= StartMoving;
    }
    void StartMoving()
    {
        canMove = true;
    }
    void Update()
    {
        if(canMove)
            // movement code
    }
    public static event System.Action PlayerTriggered;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(PlayerTriggered != null)
                PlayerTriggered();
        }
    }
