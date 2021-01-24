    Queue<GameObject> pooledObjects;
    Queue<GameObject> Capsules;
    void Start()
    {
        pooledObjects = new Queue<GameObject>();
        Capsules = new Queue<GameObject>();
    }
   
    private void createObject()
    {
        if(pooledObjects.Count > 0)
        {
            GameObject fetchedObject = pooledObjects.Dequeue();
            fetchedObject.SetActive(true);
            //Do translations,scaling or other stuff on this reference
            //Add it back to main list of things present in scene.
            Capsules.Enqueue(fetchedObject);
        } else
        {
            //Only create objects if necessary
            GameObject caps = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            Capsules.Enqueue(caps);
        }            
    }
    
    public void destroyObject()
    {
        //here instead of destorying the object we will just disable them and keep them out if scene so we dont have to recreate them everytime
        if(Capsules.Count > 0)
        {
            GameObject fetchedObject = Capsules.Dequeue();
            fetchedObject.SetActive(false);//Turn the object off from scene
            pooledObjects.Equals(fetchedObject);
        }   
    }
