    public Transform dest, target , target2;
    
    public void buttonClick()
    {
         dest = target;
    }
    
    public void buttonClick2()
    {
         dest = target2;
    }
    
    void Update()
    {
         agent.SetDestination(dest .position);
    }
