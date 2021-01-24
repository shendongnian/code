    var info = droppedObject.GetComponent<ObjectInformation>();
    // Something else dropped?
    if(!info) return;
    // Now check if the value matches
    // the one this object expects
    if(info.IsObject == ExpectedObject)
    {
        // Correct object
        Debug.Log("Yeah!");
    } 
    else 
    {
        // Wrong object
        Debug.LogFormat("Dropped object {0} does not match the expected object {1}!", info.IsObject, ExpectedObject);
    }
