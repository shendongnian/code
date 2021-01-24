    public bool detectedBefore = false;
    public Collider2D theOtherCollider;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Get both colliders then exit if we have already ran this code below
        if (detectedBefore)
        {
            //Reset
            detectedBefore = false;
    
            //Get both Colliders once below
            Collider2D col1 = theOtherCollider;
            Collider2D col2 = collision;
    
            Debug.Log("Triggered Obj1: " + col1.name);
            Debug.Log("Triggered obj2: " + col2.name);
    
            return; //EXIT the function
        }
    
        //Set the other detectedBefore variable to true then set get the first Collider
        YOURSCRIPT myScript = collision.gameObject.GetComponent<YOURSCRIPT>();
        if (myScript)
        {
            myScript.detectedBefore = true;
            myScript.theOtherCollider = collision;
        }
    
    }
