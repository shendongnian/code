    //Reference of the moving GameObject that will be corrected
    public GameObject movingObject;
    //Offset postion from where the raycast is cast from
    public Vector3 originOffset;
    public float maxRayDist = 100f;
    //The speed to apply the corrected slope angle
    public float slopeRotChangeSpeed = 10f;
    void Update()
    {
        //Get the object's position
        Transform objTrans = movingObject.transform;
        Vector3 origin = objTrans.position;
        //Only register raycast consided as Hill(Can be any layer name)
        int hillLayerIndex = LayerMask.NameToLayer("Hill");
        //Calculate layermask to Raycast to. 
        int layerMask = (1 << hillLayerIndex);
        RaycastHit slopeHit;
        //Perform raycast from the object's position downwards
        if (Physics.Raycast(origin + originOffset, Vector3.down, out slopeHit, maxRayDist, layerMask))
        {
            //Drawline to show the hit point
            Debug.DrawLine(origin + originOffset, slopeHit.point, Color.red);
            //Get slope angle from the raycast hit normal then calcuate new pos of the object
            Quaternion newRot = Quaternion.FromToRotation(objTrans.up, slopeHit.normal)
                * objTrans.rotation;
            //Apply the rotation 
            objTrans.rotation = Quaternion.Lerp(objTrans.rotation, newRot,
                Time.deltaTime * slopeRotChangeSpeed);
        }
    }
