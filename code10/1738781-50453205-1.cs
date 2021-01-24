    List<GameObject> myObjects = new List<GameObject>();
    
    if (Input.GetTouch(0).phase == TouchPhase.Began) // when user touches screen
    {
        myObjects.Add(SpawnObject()); //your method to spawn and return the spawned Gameobject to add to the list
        
        if (myObjects.Count > 2)
        {
            Destroy(myObjects[0]); // destroy the gameobject
            myObjects.RemoveAt(0); // remove from list
        }
    }
        
