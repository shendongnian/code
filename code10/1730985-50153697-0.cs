    private NavMeshAgent agent;
    private int waterMask;
    
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waterMask = 1 << NavMesh.GetAreaFromName("Water");
    }
    
    void Update()
    {
        NavMeshHit hit;
    
        // Check all areas one length unit ahead.
        if (!agent.SamplePathPosition(NavMesh.AllAreas, 1.0F, out hit))
        {
            if ((hit.mask & waterMask) != 0)
            {
                // Water detected along the path...
    
                //Move to it
                agent.SetDestination(hit.position);
            }
        }
    }
