    public Transform dest, target , target2;
    
    public static void buttonClick()
    {
         dest = target;
    }
    
    public static void buttonClick2()
    {
         dest = target2;
    }
    
    void Update()
    {
         agent.SetDestination(dest .position);
    }
