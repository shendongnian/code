    //Example raycast code
    //Variables
    public RayCastHit _Hit;
    public LayerMask _RaycastCollidableLayers; //Set this in inspector, makes you able to say which layers should be collided with and which not.
    public float _CheckDistance = 5f;
    //Method
    bool IsNotBlocked(){
    Vector3 forward = transform.TransformDirection(Vector3.forward);
    if (Physics.Raycast(transform.position, forward, out _Hit, _CheckDistance + 0.1f, _RaycastCollidableLayers))
    if (_Hit.collider == null)
    {
        Debug.Log("Raycast hit nothing");
        return true;
    }
    GameObject go = _Hit.collider.gameObject;
    if (go == null) //If no object hit, nothing is blocked.
    return true;
    else //An object was hit.
    return false;
    }
