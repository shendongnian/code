    public Collider myCollider;
   
    ...
    myCollider = GetComponent<Collider>();
    ...
  
    void OnTriggerExit(Collider other) 
    {
        if (!myCollider.isTrigger) 
        {
            return;
        } 
        // Do stuff for trigger here.
    }
  
