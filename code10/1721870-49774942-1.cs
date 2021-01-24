    bool canMove = true;
    void OnEnable()
    {
        PlayerTriggered += StopMoving;
    }
    void OnDisable()
    {
        PlayerTriggered -= StopMoving;
    }
    void StopMoving()
    {
        canMove = false;
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
