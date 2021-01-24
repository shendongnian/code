    public float fireDamageRange = 5;
    public float fireDamage = 10;
    public GameObject player; // the player
    private Vector3 origin;
    private Vector3 direction;
    
    void Update(){
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= fireDamageRange)
        {
            // handle damage to the player
        }
    }
