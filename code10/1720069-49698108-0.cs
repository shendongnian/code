    Using UnityEngine.AI;
    NavMeshAgent agent;
    public float UpdatePositionCooldown = 0.2f;
    float UpdatePositionTime;
    public Transform Player; //<-- Should be dragged in via inspector in this example
    void Awake(){
        agent = GetComponent<NavMeshAgent>();
        UpdatePositionTime = Time.time;
    }
    void Update(){
        //Set destination if cooldown done.
        if (Time.time > UpdatePositionTime){
        agent.SetDestination(Player.position);
        UpdatePositionTime = UpdatePositionCooldown + Time.time;
        }
    }
