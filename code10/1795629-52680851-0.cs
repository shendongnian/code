    // Specify the targets in the inspector
    // Make sure you have at least one target, otherwise, you will have an IndexOutOfRange Exception
    public Transform[] TargetObjects;
    public float MovementSpeed = 1;
    private bool objectMoving= false;
    private int currentTargetIndex;
    
    public void MoveObjectToTarget(Transform objectToMove, Transform target, float maxDistanceDelta )
    {
        objectToMove.position = Vector2.MoveTowards(objectToMove.position, target.position, maxDistanceDelta );
        return (objectToMove.position - target.position).sqrMagnitude < 0.01f;
    }
    
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) ) // Toggle whether the object will move to the target
            objectMoving = !objectMoving;
    
        if( objectMoving )
        {
            if( MoveObjectToTarget( transform, TargetObjects[currentTargetIndex], Time.deltaTime * MovementSpeed; ) )
            {
                Debug.Log( "Target reached" ) ;
                currentTargetIndex = (currentTargetIndex + 1) % TargetObjects.Length ;
            }
        }
    }
