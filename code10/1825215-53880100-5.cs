    Queue<GameObject> Capsules;
    void Start()
    {
        Capsules = new Queue<GameObject>();
    }
   
    private void createObject()
    {
        GameObject caps = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Capsules.Enqueue(caps);
    }
    
    public void destroyObject()
    {
        if(Capsules.Count > 0)
            Destroy(Capsules.Dequeue());   
    }
