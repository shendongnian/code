    public Vector3 sourceObject;
    public Collider targetCollider;
    
    // Update is called once per frame
    void Update()
    {
        //Method 1
        Vector3 closestPoint = targetCollider.ClosestPoint(sourceObject);
    
        //Method 2
        Vector3 closestPointInBounds = targetCollider.ClosestPointOnBounds(sourceObject);
    
        //Method 3
        Vector3 pos = targetCollider.transform.position;
        Quaternion rot = targetCollider.transform.rotation;
        Vector3 closestPointCollider = Physics.ClosestPoint(sourceObject, targetCollider, pos, rot);
    }
